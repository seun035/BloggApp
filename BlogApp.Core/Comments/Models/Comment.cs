using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Comments.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(CommentEntity commentEntity)
        {
            Id = commentEntity.Id;
            Content = commentEntity.Content;
            Author = new User(commentEntity.Author);
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }
    }
}
