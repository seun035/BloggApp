using BlogApp.Core.Accounts;
using BlogApp.Core.Auths.Models;
using BlogApp.Core.Helpers;
using BlogApp.Core.Users;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserAccountService _userAccountService;

        public AccountService(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        public async Task<AuthenticationResponse> LoginWithPasswordAsync(LoginWithPasswordModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));

            return await _userAccountService.LoginUserAsync(model.Email, model.Password);
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));

            await _userAccountService.RegisterUserAsync(model);
        }
    }
}
