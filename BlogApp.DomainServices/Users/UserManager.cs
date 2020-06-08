using BlogApp.Core.Helpers;
using BlogApp.Core.Users;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> GetUserInfoAsync(Guid userId)
        {
            ArgumentGuard.NotEmpty(userId, nameof(userId));

            // permission
            var user = await _userService.GetUserInfoAsync(userId);
            return user;
        }

        public async Task UpadateUserAsync(UpdateUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));
            //permission
            await  _userService.UpadateUserAsync(model);
        }
    }
}
