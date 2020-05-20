using BlogApp.Core.Auths.Models;
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
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserRepository _userRepository;

        public UserAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<AuthenticationResponse> LoginUserAsync(string email, string password)
        {
            ArgumentGuard.NotNull(email, nameof(email));
            ArgumentGuard.NotNull(password, nameof(password));

            var user = _userRepository.GetAsync(u => u.Email == email);

        }

        public Task RegisterUserAsync(RegisterUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
