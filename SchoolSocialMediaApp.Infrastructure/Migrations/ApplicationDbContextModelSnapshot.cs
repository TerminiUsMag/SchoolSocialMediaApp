﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSocialMediaApp.Data;

#nullable disable

namespace SchoolSocialMediaApp.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolSocialMediaDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the class");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date and time the user was created.");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The first name of the user.");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("The image url of the user.");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasComment("Is admin of the app");

                    b.Property<bool>("IsInvited")
                        .HasColumnType("bit")
                        .HasComment("Has a pending invitation for a school");

                    b.Property<bool>("IsParent")
                        .HasColumnType("bit")
                        .HasComment("Is parent in a school");

                    b.Property<bool>("IsPrincipal")
                        .HasColumnType("bit")
                        .HasComment("Is principal of a school");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("bit")
                        .HasComment("Is student in a school");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit")
                        .HasComment("Is teacher in a school");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The last name of the user.");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the parent of the user.");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PrincipledSchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the school which the user is Principal of");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the school the user is participant in.");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ParentId");

                    b.HasIndex("PrincipledSchoolId")
                        .IsUnique()
                        .HasFilter("[PrincipledSchoolId] IS NOT NULL");

                    b.HasIndex("SchoolId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ClassesAndSubjects", b =>
                {
                    b.Property<Guid>("SchoolClassId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("School Class id");

                    b.Property<Guid>("SchoolSubjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("School Subject id");

                    b.HasKey("SchoolClassId", "SchoolSubjectId");

                    b.HasIndex("SchoolSubjectId");

                    b.ToTable("ClassesAndSubjects");

                    b.HasComment("School Classes and their School Subjects");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the comment.");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("The content of the comment.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date and time the comment was created.");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the creator of the comment.");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the post the comment is on.");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasComment("A comment made by a user on a post.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the grade.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date and time the grade was created.");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the creator of the grade.");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int")
                        .HasComment("The grade itself.");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the student the grade is assigned to.");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the subject");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");

                    b.HasComment("Grade of a student");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id is the primary key of the invitation table.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("CreatedOn is the date and time the invitation was created.");

                    b.Property<bool>("IsPending")
                        .HasColumnType("bit")
                        .HasComment("IsPending is a boolean that determines if the invitation is pending.");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("ReceiverId is the foreign key of the receiver of the invitation.");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Role is the role the invitation is for.");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("SchoolId is the foreign key of the school the invitation is for.");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("SenderId is the foreign key of the sender of the invitation.");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("SenderId");

                    b.ToTable("Invitations");

                    b.HasComment("Invitation table holds all the invitations sent to users to join a school and a role in that school. It holds the sender, receiver, school, role, and status of the invitation.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the post.");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("The content of the post.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date and time the post was created.");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the post owner");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit")
                        .HasComment("Is the post edited.");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the school the post is for.");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Posts");

                    b.HasComment("A post made by a user.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.PostsLikes", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the post which is liked.");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the user who liked the post.");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostsLikes");

                    b.HasComment("Users who have liked a post");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the school.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("The description of the school.");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("The image url of the school.");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("The location of the school.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The name of the school.");

                    b.Property<Guid>("PrincipalId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the principal of the school.");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasComment("A school that has a director and students.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier of the school class");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time the class was created");

                    b.Property<int>("Grade")
                        .HasColumnType("int")
                        .HasComment("The grade of the school class");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("The name of the school class");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The school's id");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classes");

                    b.HasComment("A school class with a group of students and subjects");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier of the subject");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date and time the subject was created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Name of the subject");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The school's id");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The id of the teacher");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");

                    b.HasComment("A school subject with a teacher which teaches the subject to students");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolClass", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId");

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "PrincipledSchool")
                        .WithOne("Principal")
                        .HasForeignKey("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "PrincipledSchoolId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "School")
                        .WithMany("Participants")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Class");

                    b.Navigation("Parent");

                    b.Navigation("PrincipledSchool");

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ClassesAndSubjects", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolClass", "SchoolClass")
                        .WithMany("SchoolSubjects")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolSubject", "SchoolSubject")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("SchoolSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SchoolClass");

                    b.Navigation("SchoolSubject");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Comments")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Grade", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Creator")
                        .WithMany("GradesCreated")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolSubject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Invitation", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Receiver")
                        .WithMany("Invitations")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "School")
                        .WithMany("Invitations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Sender")
                        .WithMany("SentInvitations")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("School");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "School")
                        .WithMany("Posts")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.PostsLikes", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolClass", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolSubject", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId");

                    b.Navigation("School");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Grades");

                    b.Navigation("GradesCreated");

                    b.Navigation("Invitations");

                    b.Navigation("LikedPosts");

                    b.Navigation("Posts");

                    b.Navigation("SentInvitations");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.School", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Participants");

                    b.Navigation("Posts");

                    b.Navigation("Principal")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolClass", b =>
                {
                    b.Navigation("SchoolSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.SchoolSubject", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("SchoolClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
