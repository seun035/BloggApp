using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.UIApiServices.Comments.ViewModels
{
    public class CommentAuthor
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
