using BlogApp.UIApiServices.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.UIApiServices.Comments.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public CommentAuthor Author { get; set; }
    }
}
