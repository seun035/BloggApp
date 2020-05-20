using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Framework
{
    public interface ICryptoService
    {
        string HashPasswordKeyDerivationPbkdf2(string password, string passwordSalt);

        string GenerateSalt(int maxLength);
    }
}
