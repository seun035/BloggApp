using BlogApp.Core.Auths.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Users
{
    public interface IUserAccountService
    {
        Task<AuthenticationResponse> LoginUserAsync(string email, string password);

        Task RegisterUserAsync(RegisterUserModel model);
    }
}
