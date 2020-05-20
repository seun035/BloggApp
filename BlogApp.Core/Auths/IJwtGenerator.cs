using BlogApp.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Auths
{
    public interface IJwtGenerator
    {
        string CreateToken(IUserInfo userInfo);
    }
}
