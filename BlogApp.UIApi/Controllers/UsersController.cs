using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Accounts;
using BlogApp.Core.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UIApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public UsersController(IAccountService  accountService)
        {
            _accountService = accountService;
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            await _accountService.RegisterAsync(model);
        }

        public async Task LoginWithPasswordAsync(LoginWithPasswordModel model)
        {
            await _accountService.LoginWithPasswordAsync(model);
        }
    }
}