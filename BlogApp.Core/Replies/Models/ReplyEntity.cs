using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Replies.Models
{
    public class ReplyEntity: BaseEntity
    {
        public Guid AuthorId { get; set; }

        public Guid CommentId { get; set; }

        public string Content { get; set; }

        public UserEntity Author { get; set; }

        public CommentEntity Comment { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public Guid? LastModfiedById { get; set; }
    }
}
