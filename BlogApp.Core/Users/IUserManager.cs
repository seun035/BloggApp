using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Users
{
    public interface IUserManager
    {
        Task<User> GetUserInfoAsync(Guid userId);

        Task UpadateUserAsync(UpdateUserModel model);
    }
}
