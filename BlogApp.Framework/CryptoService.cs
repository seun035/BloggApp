using BlogApp.Core.Framework;
using BlogApp.Core.Helpers;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlogApp.Framework
{
    public class CryptoService : ICryptoService
    {
        public string GenerateSalt(int maxLength)
        {
            byte[] salt = new byte[maxLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string HashPasswordKeyDerivationPbkdf2(string password, string passwordSalt)
        {
            ArgumentGuard.NotNull(password, nameof(password));
            ArgumentGuard.NotNull(passwordSalt, nameof(passwordSalt));

            var salt = Encoding.Default.GetBytes(passwordSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
