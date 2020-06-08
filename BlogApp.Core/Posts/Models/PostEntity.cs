using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class PostEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public UserEntity Author { get; set; }

        public PostStatus Status { get; set; }

        public ICollection<TagEntity> Tags { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public Guid? LastModfiedById { get; set; }
    }
}
