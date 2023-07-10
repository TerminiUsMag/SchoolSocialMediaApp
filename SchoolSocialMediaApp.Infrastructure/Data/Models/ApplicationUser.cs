﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using validation = SchoolSocialMediaApp.Common.InfrastructureCommon.ValidationConstantsInfrastructure;

namespace SchoolSocialMediaApp.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool IsPrincipal { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsParent { get; set; }
        public bool IsStudent { get; set; }

        [Comment("The first name of the user.")]
        [MaxLength(validation.MaxFirstNameLength)]
        [Required]
        public string FirstName { get; set; } = null!;

        [Comment("The last name of the user.")]
        [MaxLength(validation.MaxLastNameLength)]
        [Required]
        public string LastName { get; set; } = null!;

        [Comment("The image url of the user.")]
        [MaxLength(validation.MaxImageUrlLength)]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("The id of the school the user is in.")]
        public Guid? SchoolId { get; set; }     //Associated school id. Example: If the user is a teacher, then the school id is the id of the school the teacher is teaching in.

        [Comment("The school the user is in.")]
        //[ForeignKey(nameof(SchoolId))]
        public School? School { get; set; }    //Associated school. Example: If the user is a parent, then the school property is navigation to the school the parent's kid is in.

        [Comment("The id of the parent of the user.")]
        public Guid? ParentId { get; set; }           //If the user is a student, then the parent id is the id of the parent of the student.

        [Comment("The parent of the user.")]
        [ForeignKey(nameof(ParentId))]
        public ApplicationUser? Parent { get; set; }     //If the user is a student, then the parent property is navigation to the parent of the student.

        [Comment("Kids of the parent.")]
        [InverseProperty(nameof(ApplicationUser.Parent))]
        public ICollection<ApplicationUser> Kids { get; set; } = new List<ApplicationUser>(); //If the user is a parent, then the kids property is navigation to the kids of the parent.

        [Comment("The id of the teacher of the user.")]
        public Guid? TeacherId { get; set; }    //If the user is a student, then the teacher id is the id of the teacher of the student.

        [Comment("The teacher of the user.")]
        [ForeignKey(nameof(TeacherId))]
        public ApplicationUser? Teacher { get; set; } //If the user is a student, then the teacher property is navigation to the teacher of the student

        [Comment("The students of the teacher.")]
        [InverseProperty(nameof(ApplicationUser.Teacher))]
        public ICollection<ApplicationUser> Students { get; set; } = new List<ApplicationUser>(); //if the user is a teacher, then the students property is navigation to the students of the teacher.

        [Comment("The date and time the user was created.")]
        [Required]
        public DateTime CreatedOn { get; set; }

        [Comment("The posts the user has liked.")]
        public ICollection<PostsLikes> LikedPosts { get; set; } = new List<PostsLikes>();

        [Comment("The posts the user has disliked.")]
        public ICollection<PostsDislikes> DislikedPosts { get; set; } = new List<PostsDislikes>();

        [Comment("The comments the user has liked.")]
        public ICollection<CommentsLikes> LikedComments { get; set; } = new List<CommentsLikes>();

        [Comment("The comments the user has disliked.")]
        public ICollection<CommentsDislikes> DislikedComments { get; set; } = new List<CommentsDislikes>();

        [Comment("The posts made by the user.")]
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        [Comment("The comments made by the user.")]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [Comment("The invitations the user has received.")]
        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        [Comment("The invitations the user has sent.")]
        public ICollection<Invitation> SentInvitations { get; set; } = new List<Invitation>();
    }
}
