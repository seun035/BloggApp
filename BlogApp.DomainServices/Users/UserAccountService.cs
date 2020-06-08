using BlogApp.Core.Auths;
using BlogApp.Core.Auths.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Exceptions;
using BlogApp.Core.Framework;
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
        private readonly ICryptoService _cryptoService;
        private readonly IJwtGenerator _jwtGenerator;

        public UserAccountService(IUserRepository userRepository, ICryptoService cryptoService, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthenticationResponse> LoginUserAsync(string email, string password)
        {
            ArgumentGuard.NotNull(email, nameof(email));
            ArgumentGuard.NotNull(password, nameof(password));

            var userEntity = await _userRepository.GetAsync(u => u.Email == email);
            var user = new User(userEntity);

            var hashPassword = _cryptoService.HashPasswordKeyDerivationPbkdf2(password, user.Salt);

            if (hashPassword != user.Password)
            {
                // throw
                throw new AppException(400, "Invalid credentials");
            }

            var token = _jwtGenerator.CreateToken(user);
            return new AuthenticationResponse { Token = token };
        }

        public async Task RegisterUserAsync(RegisterUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));

            // validate
            var userId = Guid.NewGuid();
            var salt = _cryptoService.GenerateSalt(32);
            var password = _cryptoService.HashPasswordKeyDerivationPbkdf2(model.Password, salt);

            var user = new UserEntity
            {
                Id = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Salt = salt,
                Password = password,
                ProfileImageUrl = model.ProfileImageUrl,
                TwitterProfileUrl = model.TwitterProfileUrl,
                LinkedInProfileUrl = model.LinkedInProfileUrl,
                GitHubProfileUrl = model.GitHubProfileUrl,
                CreatedDateUtc = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
        }
    }
}
