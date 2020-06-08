using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Users.Models
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }

        public string ProfileImageUrl { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string TwitterProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }

        public ICollection<PostEntity> Posts { get; set; }
    }
}
