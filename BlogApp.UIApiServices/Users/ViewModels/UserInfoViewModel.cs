using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.UIApiServices.Users.ViewModels
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ProfileImageUrl { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string TwitterProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }
    }
}
