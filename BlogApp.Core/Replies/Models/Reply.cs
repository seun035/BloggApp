using BlogApp.Core.Comments.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Replies.Models
{
    public class Reply
    {
        public Reply(ReplyEntity replyEntity)
        {
            Id = replyEntity.Id;
            Content = replyEntity.Content;
            Author = new User(replyEntity.Author);
            // Comment = new Comment(replyEntity.Comment);
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        // public Comment Comment { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public Guid? LastModfiedById { get; set; }
    }
}
