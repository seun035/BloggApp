using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Users
{
    public interface IUserInfo
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }
    }
}
