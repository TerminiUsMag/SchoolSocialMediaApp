﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSocialMediaApp.Core.Contracts;
using SchoolSocialMediaApp.Infrastructure.Common;
using SchoolSocialMediaApp.Infrastructure.Data.Models;
using SchoolSocialMediaApp.Infrastructure.Migrations;
using SchoolSocialMediaApp.ViewModels.Models.Admin;
using SchoolSocialMediaApp.ViewModels.Models.Post;
using SchoolSocialMediaApp.ViewModels.Models.School;
using SchoolSocialMediaApp.ViewModels.Models.SchoolClass;
using SchoolSocialMediaApp.ViewModels.Models.SchoolSubject;
using SchoolSocialMediaApp.ViewModels.Models.Student;
using SchoolSocialMediaApp.ViewModels.Models.Teacher;
using SchoolSocialMediaApp.ViewModels.Models.User;
using System.Net.Mail;
using System.Text.RegularExpressions;
using validation = SchoolSocialMediaApp.Common.ValidationConstants;

namespace SchoolSocialMediaApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWebHostEnvironment env;
        private readonly IRoleService roleService;
        private readonly IRepository repo;
        private readonly ISchoolService schoolService;
        private readonly ISchoolSubjectService subjectService;
        public AccountService(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IRepository _repo,
            IRoleService _roleService,
            IWebHostEnvironment _env,
            ISchoolService _schoolService,
            ISchoolSubjectService _subjectService)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.roleService = _roleService;
            this.repo = _repo;
            this.env = _env;
            this.schoolService = _schoolService;
            this.subjectService = _subjectService;
        }

        public async Task DeleteAsync(Guid userId)
        {
            //Get the user entity from the DB with his posts, comments, likes and invitations.
            var user = await repo.All<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Posts).Include(u => u.Comments).Include(u => u.LikedPosts).Include(u => u.Invitations).FirstOrDefaultAsync();

            //Checks if the user is not found and throws and exception.
            if (user == null) throw new ArgumentNullException("User is empty");

            //Set variables for user's posts, comments, likes and invitations for readability.
            var posts = user.Posts;
            var comments = user.Comments;
            var postLikes = user.LikedPosts;
            var invitations = user.Invitations;

            //Checks for comments, if there are comments they get deleted.
            if (comments.Any())
            {
                repo.DeleteRange(comments);
            }
            //Checks for likes, if there are likes they get removed.
            if (postLikes.Any())
            {
                repo.DeleteRange(postLikes);
            }
            //Checks for posts, if there are posts they get deleted.
            if (posts.Any())
            {
                repo.DeleteRange(posts);
            }
            //Checks for invitations if there are invitations they get deleted.
            if (invitations.Any())
            {
                repo.DeleteRange(invitations);
            }
            //Saves all changes to the DB.
            await repo.SaveChangesAsync();

            //Checks if the account is linked to one of the demo profile pictures and if not deletes the custom profile picture of the user from the storage to save space.
            if (user.ImageUrl != "/images/user-images/principalProfile.jpg" && user.ImageUrl != "/images/user-images/studentProfile.jpg" && user.ImageUrl != "/images/defaultProfile.png")
            {

                string imageUrl = user.ImageUrl.Substring(1);
                string filePath = Path.Combine(env.WebRootPath, imageUrl);

                // Check if the file exists before attempting to delete
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            //Deletes the user from the DB and saves the changes.
            await userManager.DeleteAsync(user);
            await signInManager.SignOutAsync();
        }

        public async Task<bool> EmailIsFreeAsync(string email)
        {
            var result = await userManager.FindByEmailAsync(email.ToUpper());

            if (result is null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EmailIsFreeAsync(string email, Guid userId)
        {
            var result = await repo.All<ApplicationUser>().Where(u => u.Id != userId).FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

            if (result is null)
            {
                return true;
            }
            return false;
        }

        public bool EmailIsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<AdminPanelViewModel> GetAdminPanelViewModelAsync(Guid userId)
        {
            var isAdmin = await roleService.UserIsInRoleAsync(userId.ToString(), "Admin");
            if (!isAdmin)
            {
                throw new InvalidOperationException("You are not admin!");
            }
            var result = new AdminPanelViewModel();
            var posts = await repo.All<Post>().ToListAsync();
            var users = await repo.All<ApplicationUser>().Where(u => u.Id != userId && u.IsAdmin == false).ToListAsync();
            var admins = await repo.All<ApplicationUser>().Where(u => u.Id != userId && u.IsAdmin == true).ToListAsync();
            var schools = await repo.All<School>().Include(s => s.Principal).Select(s => new SchoolManageViewModel
            {
                Description = s.Description,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Location = s.Location,
                Name = s.Name,
                PrincipalId = s.PrincipalId,
                ImageFile = null,
                Principal = s.Principal,
                Parents = new List<ApplicationUser>(),
                Students = new List<ApplicationUser>(),
                Teachers = new List<ApplicationUser>(),
                Posts = new List<PostViewModel>(),
            }).ToListAsync();

            schools = schools.DistinctBy(s => s.Id).ToList();

            foreach (var school in schools)
            {
                var schoolUsers = users.Where(u => u.SchoolId == school.Id).ToList();
                var schoolPosts = posts.Where(p => p.SchoolId == school.Id).ToList();
                foreach (var user in schoolUsers)
                {
                    if (user.IsParent)
                    {
                        school.Parents.Add(user);
                    }
                    else if (user.IsStudent)
                    {
                        school.Students.Add(user);
                    }
                    else
                    {
                        if (!user.IsPrincipal)
                        {
                            school.Teachers.Add(user);
                        }
                    }
                }
            }

            foreach (var user in users)
            {
                user.Posts = posts.Where(p => p.CreatorId == user.Id).ToList();
            }

            result.Schools = schools;
            result.Users = users;
            result.Admins = admins;
            return result;
        }

        public async Task<AdminUserDeletionViewModel> GetAdminUserDeletionViewModelAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("User id cannot be empty");
            }
            var user = await repo.All<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new ArgumentException("No user found with Id: " + userId);
            }

            return new AdminUserDeletionViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                Username = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };

        }

        public async Task<MakeUserAdminViewModel> GetMakeUserAdminViewModelAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("User id cannot be empty");
            }
            var user = await repo.All<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new ArgumentException("No user found with Id: " + userId);
            }

            return new MakeUserAdminViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                Username = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public async Task<StudentPanelViewModel> GetStudentPanelViewModelAsync(Guid userId)
        {
            var user = await repo.All<ApplicationUser>().Include(u => u.Class).ThenInclude(c => c!.SchoolSubjects).FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                throw new ArgumentException("No such user");

            var userIsTeacher = await roleService.UserIsInRoleAsync(userId.ToString(), "Student");
            if (!userIsTeacher)
                throw new ArgumentException("User is not a student !");

            var schoolId = user.SchoolId;
            var school = await repo.All<School>().Include(s => s.Principal).FirstOrDefaultAsync(s => s.Id == schoolId);
            if (school is null)
                throw new ArgumentException("No such school");

            var studentPanelViewModel = new StudentPanelViewModel();

            if (user.Class is not null)
            {
                var schoolSubjects = await repo.All<ClassesAndSubjects>().Where(cas => cas.SchoolClassId == user.Class.Id).Include(cas => cas.SchoolSubject).ThenInclude(ss => ss.Teacher).ToListAsync();

                studentPanelViewModel.SchoolClass = new SchoolClassViewModel
                {
                    CreatedOn = user.Class.CreatedOn,
                    Grade = user.Class.Grade,
                    Id = user.Class.Id,
                    Name = user.Class.Name,
                    School = new SchoolViewModel
                    {
                        Description = school.Description,
                        Name = school.Name,
                        Id = school.Id,
                        ImageUrl = school.ImageUrl,
                        Location = school.Location,
                        PrincipalId = school.PrincipalId,
                        PrincipalName = school.Principal.FirstName + " " + school.Principal.LastName
                    },
                    SchoolId = user.Class.SchoolId,
                    Students = user.Class.Students,
                    Subjects = schoolSubjects.Select(ss => new SchoolSubjectViewModel
                    {
                        CreatedOn = ss.SchoolSubject.CreatedOn,
                        Id = ss.SchoolSubject.Id,
                        Name = ss.SchoolSubject.Name,
                        SchoolId = ss.SchoolSubject.SchoolId,
                        TeacherId = ss.SchoolSubject.TeacherId,
                        TeacherName = ss.SchoolSubject.Teacher!.FirstName + " " + ss.SchoolSubject.Teacher.LastName

                    }).ToList(),
                };

                var classMates = await repo.All<ApplicationUser>().Where(u => u.ClassId == user.ClassId).Include(u => u.Class).ToListAsync();

                foreach (var classMateToProcess in classMates)
                {
                    var classMate = new StudentViewModel
                    {
                        ClassId = classMateToProcess.ClassId.GetValueOrDefault(),
                        FirstName = classMateToProcess.FirstName,
                        LastName = classMateToProcess.LastName,
                        Id = classMateToProcess.Id,
                        Class = new SchoolClassViewModel
                        {
                            CreatedOn = classMateToProcess.Class!.CreatedOn,
                            Grade = classMateToProcess.Class.Grade,
                            Name = classMateToProcess.Class.Name,
                            Id = classMateToProcess.Class.Id,
                            SchoolId = classMateToProcess.Class.SchoolId,
                        }
                    };
                    studentPanelViewModel.Classmates.Add(classMate);
                }
            }

            return studentPanelViewModel;
        }

        public async Task<StudentSubjectClassViewModel> GetStudentSubjectClassViewModelAsync(Guid subjectId, Guid classId, Guid studentId)
        {
            if (await repo.All<ApplicationUser>().FirstOrDefaultAsync(au => au.Id == studentId) is null)
                throw new ArgumentException("No such user found");
            if (await repo.All<SchoolClass>().FirstOrDefaultAsync(sc => sc.Id == classId) is null)
                throw new ArgumentException("No such class found");
            if (await repo.All<SchoolSubject>().FirstOrDefaultAsync(ss => ss.Id == subjectId) is null)
                throw new ArgumentException("No such subject found");

            var schoolClassesAndSubjects = await repo.All<ClassesAndSubjects>().Include(cas=>cas.SchoolSubject).ThenInclude(ss=>ss.Teacher).Include(cas=>cas.SchoolClass).ThenInclude(sc=>sc.Students).FirstOrDefaultAsync(cas=>cas.SchoolClassId == classId && cas.SchoolSubjectId == subjectId);

            if (schoolClassesAndSubjects is null)
                throw new ArgumentException("No such Class - Subject relation found!");

            var schoolClass = schoolClassesAndSubjects!.SchoolClass;
            var schoolSubject = schoolClassesAndSubjects.SchoolSubject;

            var model = new StudentSubjectClassViewModel();

            model.SubjectId = subjectId;
            model.ClassId = classId;
            model.StudentId = studentId;

            model.Subject = new SchoolSubjectViewModel
            {
                Id = schoolSubject.Id,
                Classes = await GetClassesBySubjectId(schoolSubject.Id),
                CreatedOn = schoolSubject.CreatedOn,
                Name = schoolSubject.Name,
                TeacherName = schoolSubject.Teacher!.FirstName + " " + schoolSubject.Teacher.LastName,
                Teacher = schoolSubject.Teacher,
                SchoolId = schoolSubject.SchoolId,
                TeacherId = schoolSubject.TeacherId,
            };
            model.Class = new SchoolClassViewModel
            {
                CreatedOn = schoolClass.CreatedOn,
                Name = schoolClass.Name,
                Grade = schoolClass.Grade,
                Id = schoolClass.Id,
                SchoolId = schoolClass.SchoolId,
                Students = schoolClass.Students,
            };

            var classStudent = schoolClass.Students.FirstOrDefault(s => s.Id == studentId);

            model.Student = new StudentViewModel
            {
                Class = model.Class,
                Id = studentId,
                ClassId = classId,
                FirstName = classStudent!.FirstName,
                LastName = classStudent.LastName,
            };

            return model;
        }

        private async Task<ICollection<SchoolClassViewModel>> GetClassesBySubjectId(Guid subjectId)
        {
            List<SchoolClassViewModel> schoolClasses = new List<SchoolClassViewModel>();

            var classesAndSubjects = await repo.All<ClassesAndSubjects>().Where(cas => cas.SchoolSubjectId == subjectId).ToListAsync();

            foreach (var classAndSubject in classesAndSubjects)
            {
                var schoolClassViewModel = new SchoolClassViewModel
                {
                    CreatedOn = classAndSubject.SchoolClass.CreatedOn,
                    Grade = classAndSubject.SchoolClass.Grade,
                    Id = classAndSubject.SchoolClass.Id,
                    Name = classAndSubject.SchoolClass.Name,
                    SchoolId = classAndSubject.SchoolClass.SchoolId,
                    Students = classAndSubject.SchoolClass.Students,
                };
                schoolClasses.Add(schoolClassViewModel);
            }
            return schoolClasses;
        }

        public async Task<TeacherPanelViewModel> GetTeacherPanelViewModelAsync(Guid userId)
        {
            var user = await repo.All<ApplicationUser>().Include(u => u.Subjects).FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                throw new ArgumentException("No such user");

            var userIsTeacher = await roleService.UserIsInRoleAsync(userId.ToString(), "Teacher");
            if (!userIsTeacher)
                throw new ArgumentException("User is not a teacher !");

            var schoolId = user.SchoolId;
            var school = await repo.All<School>().Include(s => s.Principal).FirstOrDefaultAsync(s => s.Id == schoolId);
            if (school is null)
                throw new ArgumentException("No such school");

            var teacherPanelViewModel = new TeacherPanelViewModel();
            teacherPanelViewModel.School = new SchoolViewModel
            {
                Id = school.Id,
                Description = school.Description,
                ImageUrl = school.ImageUrl,
                Location = school.Location,
                Name = school.Name,
                PrincipalId = school.PrincipalId,
                PrincipalName = $"{school.Principal.FirstName} {school.Principal.LastName}"
            };

            var subjects = user.Subjects.Select(s => new SchoolSubjectViewModel
            {
                Id = s.Id,
                CreatedOn = s.CreatedOn,
                Name = s.Name,
                TeacherId = s.TeacherId,
                TeacherName = user.FirstName + " " + user.LastName,
                SchoolId = s.SchoolId,
                Teacher = user,
            });

            if (subjects.Any())
            {
                foreach (var subject in subjects)
                {
                    var schoolClassesInSubject = await subjectService.GetAssignedClassesAsync(subject.Id);
                    foreach (var schoolClass in schoolClassesInSubject)
                    {
                        subject.Classes.Add(schoolClass);
                        schoolClass.Subjects.Add(subject);
                    }
                    teacherPanelViewModel.SchoolClasses.AddRange(schoolClassesInSubject);
                    teacherPanelViewModel.SchoolSubjects.Add(subject);
                }
            }
            return teacherPanelViewModel;
        }

        public async Task<UserManageViewModel> GetUserManageViewModelAsync(string userId)
        {
            if (userId is null || userId == Guid.Empty.ToString())
            {
                throw new ArgumentException("User does not exist");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("User does not exist");
            }

            return new UserManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl,
            };

        }

        public async Task<bool> LoginAsync(string email, string password, bool rememberMe)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return false;
            }
            var result = await signInManager.PasswordSignInAsync(user, password, rememberMe, true);
            if (result.Succeeded)
            {
                signInManager.Logger.LogInformation("User logged in.");
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task MakeAdminAsync(ApplicationUser user)
        {
            if (user.SchoolId is not null)
            {
                if (user.IsPrincipal)
                {
                    throw new ArgumentException("Principals cannot be admins");
                }
                Guid schoolId = (Guid)user.SchoolId;
                await schoolService.RemoveUserFromSchoolAsync(user.Id, schoolId);
            }

            var roles = await roleService.GetUserRolesAsync(user.Id);
            foreach (var role in roles)
            {
                await roleService.RemoveUserFromRoleAsync(user.Id.ToString(), role);
            }
            await repo.SaveChangesAsync();
            await roleService.AddUserToRoleAsync(user.Id.ToString(), "Admin");
        }

        public async Task<bool> PhoneNumberIsFreeAsync(string phoneNumber)
        {
            var result = await repo.AllReadonly<ApplicationUser>().FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (result is null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PhoneNumberIsFreeAsync(string phoneNumber, Guid userId)
        {
            var result = await repo.AllReadonly<ApplicationUser>().Where(u => u.Id != userId).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (result is null)
            {
                return true;
            }
            return false;
        }

        public bool PhoneNumberIsValid(string phoneNumber)
        {
            var phoneRegex = new Regex(validation.PhoneNumberRegEx);
            if (!phoneRegex.IsMatch(phoneNumber))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RegisterAsync(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (await roleService.RoleExistsAsync("User"))
                    await userManager.AddToRoleAsync(user, "User");

                await signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Guid userId, UserManageViewModel model)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user is null)
            {
                throw new ArgumentException("User doesn't exist");
            }

            try
            {
                // Get the uploaded file from the request
                var file = model.ImageFile;
                var fileExtension = Path.GetExtension(file?.FileName);

                // Check if a file was uploaded
                if ((file is not null || file?.Length != 0) && (fileExtension == ".jpg" || fileExtension == ".png"))
                {


                    // Create a unique file name to save the uploaded image
                    var fileName = Guid.NewGuid().ToString() + fileExtension;

                    // Specify the directory where the image will be saved
                    var imagePath = Path.Combine(env.WebRootPath, "images", "user-images", fileName);

                    // Save the file to the specified path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await file!.CopyToAsync(stream);
                    }

                    model.ImageUrl = $"/images/user-images/{fileName}";
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = $"{model.FirstName.ToLower()}.{model.LastName.ToLower()}";
            user.NormalizedUserName = user.UserName.ToUpper();
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();
            user.PhoneNumber = model.PhoneNumber;
            user.ImageUrl = model.ImageUrl;
            user.NormalizedEmail = model.Email.ToUpper();

            await repo.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(Guid userId)
        {
            if (await repo.AllReadonly<ApplicationUser>().FirstOrDefaultAsync(x => x.Id == userId) is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UsernameIsFreeAsync(string username)
        {
            var result = await repo.AllReadonly<ApplicationUser>().FirstOrDefaultAsync(x => x.NormalizedUserName == username.ToUpper());

            if (result is null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UsernameIsFreeAsync(string username, Guid userId)
        {
            var result = await repo.AllReadonly<ApplicationUser>().Where(u => u.Id != userId).FirstOrDefaultAsync(x => x.NormalizedUserName == username.ToUpper());

            if (result is null)
            {
                return true;
            }
            return false;
        }
    }
}
