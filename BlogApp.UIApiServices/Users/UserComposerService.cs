using AutoMapper;
using BlogApp.Core.Users;
using BlogApp.Core.Users.Models;
using BlogApp.UIApiServices.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UIApiServices.Users
{
    public class UserComposerService : IUserComposerService
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserComposerService(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserInfoViewModel> GetUserInfoAsync(Guid userId)
        {
            var user = await _userManager.GetUserInfoAsync(userId);
            return _mapper.Map<UserInfoViewModel>(user);
        }

        public async Task UpadateUserAsync(SaveUserModel model, Guid userId)
        {
            UpdateUserModel updateUserModel = new UpdateUserModel
            {
                Id = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GitHubProfileUrl = model.GitHubProfileUrl,
                LinkedInProfileUrl = model.LinkedInProfileUrl,
                ProfileImageUrl = model.ProfileImageUrl,
                TwitterProfileUrl = model.TwitterProfileUrl 
            };

            await _userManager.UpadateUserAsync(updateUserModel);
        }
    }

    public interface IUserComposerService
    {
        Task<UserInfoViewModel> GetUserInfoAsync(Guid userId);

        Task UpadateUserAsync(SaveUserModel model, Guid userId);
    }
}
