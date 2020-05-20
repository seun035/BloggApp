using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Users.Models
{
    public class RegisterUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
