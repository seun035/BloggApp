using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Replies.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Comments.Models
{
    public class CommentEntity: BaseEntity
    {
        public Guid PostId { get; set; }

        public Guid AuthorId { get; set; }

        public string Content { get; set; }

        public UserEntity Author { get; set; }

        public PostEntity Post { get; set; }

        //public ICollection<ReplyEntity> Replies { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public Guid? LastModfiedById { get; set; }
    }
}
