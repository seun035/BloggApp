using BlogApp.Core.Auths.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Accounts
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> LoginWithPasswordAsync(LoginWithPasswordModel model);

        Task RegisterAsync(RegisterUserModel model);
    }
}
