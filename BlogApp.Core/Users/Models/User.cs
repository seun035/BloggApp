using BlogApp.Core.Comments.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Core.Users.Models
{
    public class User :IUser, IUserInfo
    {
        public User()
        {

        }

        public User(UserEntity userEntity)
        {
            Id = userEntity.Id;
            FirstName = userEntity.FirstName;
            LastName = userEntity.LastName;
            Email = userEntity.Email;
            Password = userEntity.Password;
            Salt = userEntity.Salt;
            ProfileImageUrl = userEntity.ProfileImageUrl;
            LinkedInProfileUrl = userEntity.LinkedInProfileUrl;
            TwitterProfileUrl = userEntity.TwitterProfileUrl;
            GitHubProfileUrl = userEntity.GitHubProfileUrl;
            //Posts = userEntity.Posts?.Select(x => new Post(x)).ToList();
            //Comments = userEntity.Comments?.Select().ToList();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string ProfileImageUrl { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string TwitterProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }

        //public ICollection<Post> Posts { get; set; }

        //public ICollection<Comment> Comments { get; set; }

        //public ICollection<Reply> Replies { get; set; }
    }
}
