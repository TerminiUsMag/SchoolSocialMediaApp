﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSocialMediaApp.Data;

#nullable disable

namespace SchoolSocialMediaApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230622170159_RemovedPostsCommentsUnnecessaryMappingTable")]
    partial class RemovedPostsCommentsUnnecessaryMappingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The first name of the user.");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.ToTable("Comment");

                    b.HasComment("A comment made by a user on a post.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.CommentsDislikes", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the user who disliked the comment.");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the comment which is disliked.");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentsDislikes");

                    b.HasComment("Comments which are disliked by users");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.CommentsLikes", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the user who liked the comment.");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the comment which is liked.");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentsLikes");

                    b.HasComment("Comments liked by user");
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

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Post");

                    b.HasComment("A post made by a user.");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.PostsDislikes", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the post which is disliked.");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier for the user who disliked the post.");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostsDislikes");

                    b.HasComment("Users who have disliked a post");
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

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.CommentsDislikes", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.Comment", "Comment")
                        .WithMany("Dislikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("DislikedComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.CommentsLikes", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("LikedComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.PostsDislikes", b =>
                {
                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", "Post")
                        .WithMany("Dislikes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("DislikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
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

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("DislikedComments");

                    b.Navigation("DislikedPosts");

                    b.Navigation("LikedComments");

                    b.Navigation("LikedPosts");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Navigation("Dislikes");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("SchoolSocialMediaApp.Infrastructure.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Dislikes");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
