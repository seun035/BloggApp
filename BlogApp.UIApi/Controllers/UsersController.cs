using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Accounts;
using BlogApp.Core.Users.Models;
using BlogApp.UIApiServices.Users;
using BlogApp.UIApiServices.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UIApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserComposerService _userComposerService;

        public UsersController(IUserComposerService userComposerService )
        {
            _userComposerService = userComposerService;
        }

        [HttpGet("{userId:Guid}")]
        public async Task<UserInfoViewModel> UserInfo(Guid userId)
        {
            return await _userComposerService.GetUserInfoAsync(userId);
        }

        [HttpPut("{userId:Guid}")]
        public async Task UpdateUserInfo([FromBody] SaveUserModel model, Guid userId)
        {
            await _userComposerService.UpadateUserAsync(model, userId);
        }

        //[AllowAnonymous]
        //[HttpGet("_usercontext")]
        //public UserContextViewModel GetUserContext()
        //{
        //    return _userComposerService.GetUserContext();
        //}

    }
}