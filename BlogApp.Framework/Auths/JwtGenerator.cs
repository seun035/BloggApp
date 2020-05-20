using BlogApp.Core.Auths;
using BlogApp.Core.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Framework.Auths
{
    public class JwtGenerator : IJwtGenerator
    {
        public string CreateToken(IUserInfo userInfo)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Key"));
            var signInCredential = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(claims: claims, signingCredentials: signInCredential, expires: DateTime.Now.AddDays(7));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
