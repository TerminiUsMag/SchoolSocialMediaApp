﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSocialMediaApp.Core.Contracts;
using SchoolSocialMediaApp.Infrastructure.Common;
using SchoolSocialMediaApp.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SchoolSocialMediaApp.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRepository repo;

        public RoleService(
            RoleManager<ApplicationRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IRepository _repo)
        {
            this.roleManager = _roleManager;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.repo = _repo;
        }

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName, string changingUserId = "")
        {
            //Gets the user and checks if exists.
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new ArgumentException("User does not exist");
            }

            ApplicationUser changingUser = user;
            if (userId != changingUserId && changingUserId != "")
                changingUser = await userManager.FindByIdAsync(changingUserId);

            try
            {
                //checks id the role exists.
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                //if its doesn't exist tries to create it.
                if (!roleExists)
                {
                    roleExists = await CreateRoleAsync(roleName);
                }

                //if failed creating the role throws exception.
                if (!roleExists)
                {
                    throw new ArgumentException("Role could not be created.");
                }
                //Sets the user's role and based on that modifies his properties.
                var result = await userManager.AddToRoleAsync(user, roleName);
                if (roleName.ToLower() == "principal")
                {
                    user.IsPrincipal = true;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Principal"));
                }
                else if (roleName.ToLower() == "teacher")
                {
                    user.IsTeacher = true;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Teacher"));
                }
                else if (roleName.ToLower() == "student")
                {
                    user.IsStudent = true;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Student"));
                }
                else if (roleName.ToLower() == "parent")
                {
                    user.IsParent = true;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Parent"));
                }
                else if (roleName.ToLower() == "admin")
                {
                    user.IsAdmin = true;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
                }
                //Refreshes the Sign In to refresh user's roles and get the permissions of the new role without logingout.
                await signInManager.RefreshSignInAsync(user);
                await signInManager.RefreshSignInAsync(changingUser);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddUserToRoleIdAsync(Guid userId, Guid roleId, string changingUserId = "")
        {
            var role = await repo.All<ApplicationRole>().Where(r => r.Id == roleId).FirstOrDefaultAsync();

            if (role is null)
            {
                throw new ArgumentException("A role with this ID doesn't exist");
            }

            var roleName = role.Name;
                await this.AddUserToRoleAsync(userId.ToString(), roleName, changingUserId);
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            //creates the role.
            var role = new ApplicationRole { Name = roleName };
            //adds the role to the rolemanager.
            var result = await roleManager.CreateAsync(role);

            //checks if it was successfull.
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SelectListItem>> GetRolesAsync()
        {
            var result = new List<SelectListItem>();
            var roles = await roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                result.Add(new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id.ToString(),
                });
            }

            return result;
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            //gets the user and checks if it exists.
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new ArgumentException("The user doesn't exist.");
            }

            var result = new List<string>();
            //Checks each role and ads it in the result List if the user is assigned to it.
            if (await userManager.IsInRoleAsync(user, "Principal"))
            {
                result.Add("Principal");
            }
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {
                result.Add("Teacher");
            }
            if (await userManager.IsInRoleAsync(user, "Student"))
            {
                result.Add("Student");
            }
            if (await userManager.IsInRoleAsync(user, "Parent"))
            {
                result.Add("Parent");
            }
            if (await userManager.IsInRoleAsync(user, "Admin"))
            {
                result.Add("Admin");
            }
            if (await userManager.IsInRoleAsync(user, "User"))
            {
                result.Add("User");
            }

            //returns the result.
            return result;
        }

        public bool IsUserPartOfSchool(ApplicationUser user)
        {
            //gets the user and checks if exists.
            var u = user;
            if (u is null)
                return false;

            //If the user exists checks if he has assigned school to it and if he is in one of the roles.
            if (!u.IsParent && !u.IsPrincipal && !u.IsTeacher && !u.IsStudent && (u.SchoolId is null || u.SchoolId == Guid.Empty))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            //Get the user and check if it exists. 
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new ArgumentException("User does not exist");
            }

            //Remove the user from the role and refresh his signIn to remove his permissions.
            try
            {
                var result = await userManager.RemoveFromRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    await signInManager.RefreshSignInAsync(user);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            //checks if a role exists.
            var roleExists = await roleManager.RoleExistsAsync(roleName);

            //If the role doesn't exist it creates it.
            if (!roleExists)
            {
                if (!await CreateRoleAsync(roleName))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> UserIsInRoleAsync(string userId, string roleName)
        {
            //Get the user and check if he exists.
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new ArgumentException("User does not exist");
            }
            //checks if the user is in the role.
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                return false;
            }
            return true;
        }
    }
}
