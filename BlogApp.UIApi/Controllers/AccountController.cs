using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Accounts;
using BlogApp.Core.Auths.Models;
using BlogApp.Core.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApp.UIApi.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task RegisterAsync(RegisterUserModel model)
        {
            await _accountService.RegisterAsync(model);
        }

        [HttpGet("login")]
        public async Task<AuthenticationResponse> LoginWithPasswordAsync(LoginWithPasswordModel model)
        {
            return await _accountService.LoginWithPasswordAsync(model);
        }

    }
}