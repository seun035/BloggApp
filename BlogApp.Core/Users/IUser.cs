using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Users
{
    public interface IUser
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        string ProfileImageUrl { get; set; }

        string LinkedInProfileUrl { get; set; }

        string TwitterProfileUrl { get; set; }

        string GitHubProfileUrl { get; set; }

        ICollection<Post> Posts { get; set; }
    }
}
