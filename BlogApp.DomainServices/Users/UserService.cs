using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using BlogApp.Core.Users;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Users
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserInfoAsync(Guid userId)
        {
            ArgumentGuard.NotEmpty(userId, nameof(userId));

            var userEntity = await _userRepository.GetAsync(userId);
            return new User(userEntity);
        }

        public async Task UpadateUserAsync(UpdateUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));
            ArgumentGuard.NotEmpty(model.Id, nameof(model.Id));

            // validate

            var userEntity = await _userRepository.GetAsync(model.Id);
            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.GitHubProfileUrl = model.GitHubProfileUrl;
            userEntity.LinkedInProfileUrl = model.LinkedInProfileUrl;
            userEntity.TwitterProfileUrl = model.TwitterProfileUrl;

            await _userRepository.UpdateAsync(userEntity);

        }
    }
}
