﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolSocialMediaApp.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace SchoolSocialMediaApp.Data
{
    public class SchoolSocialMediaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        //private bool seedDb;

        public SchoolSocialMediaDbContext(DbContextOptions<SchoolSocialMediaDbContext> options/*, bool seed = true*/)
            : base(options)
        {
            //this.seedDb = seed;
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }
        }

        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<PostsLikes> PostsLikes { get; set; } = null!;
        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Invitation> Invitations { get; set; } = null!;
        public DbSet<SchoolClass> Classes { get; set; } = null!;
        public DbSet<SchoolSubject> Subjects { get; set; } = null!;
        public DbSet<ClassesAndSubjects> ClassesAndSubjects { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //if (this.seedDb)
            //{
            //    builder.ApplyConfiguration(new RolesConfiguration());
            //    builder.ApplyConfiguration(new UserConfiguration());
            //    //builder.ApplyConfiguration(new SchoolConfiguration());
            //}

            builder.Entity<PostsLikes>()
                .HasKey(pl => new { pl.PostId, pl.UserId });

            builder.Entity<Comment>()
                .HasOne(Comment => Comment.Creator)
                .WithMany(User => User.Comments)
                .HasForeignKey(Comment => Comment.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>()
                .HasOne(Comment => Comment.Post)
                .WithMany(Post => Post.Comments)
                .HasForeignKey(Comment => Comment.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PostsLikes>()
                .HasOne(pl => pl.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(pl => pl.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.PrincipledSchool)
                .WithOne(s => s.Principal)
                .HasForeignKey<School>(s => s.PrincipalId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.School)
                .WithMany(s => s.Participants)
                .HasForeignKey(u => u.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.HasIndex(u => u.SchoolId).IsUnique(false);
            //});

            builder.Entity<School>()
                .HasOne(s => s.Principal)
                .WithOne(p => p.PrincipledSchool)
                .HasForeignKey<ApplicationUser>(u => u.PrincipledSchoolId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<School>()
                .HasMany(s => s.Participants)
                .WithOne(u => u.School)
                .HasForeignKey(u => u.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Invitation>()
                .HasOne(i => i.School)
                .WithMany(s => s.Invitations)
                .HasForeignKey(i => i.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Invitation>()
                .HasOne(i => i.Receiver)
                .WithMany(r => r.Invitations)
                .HasForeignKey(i => i.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Invitation>()
                .HasOne(i => i.Sender)
                .WithMany(s => s.SentInvitations)
                .HasForeignKey(i => i.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ClassesAndSubjects>()
                .HasKey(scs => new { scs.SchoolClassId, scs.SchoolSubjectId });

            builder.Entity<ClassesAndSubjects>()
                .HasOne(scs => scs.SchoolClass)
                .WithMany(sc => sc.SchoolSubjects)
                .HasForeignKey(scs => scs.SchoolClassId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ClassesAndSubjects>()
                .HasOne(cas => cas.SchoolSubject)
                .WithMany(ss => ss.SchoolClasses)
                .HasForeignKey(cas => cas.SchoolSubjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Grade>()
                .HasOne(g => g.Creator)
                .WithMany(u => u.GradesCreated)
                .HasForeignKey(g => g.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}