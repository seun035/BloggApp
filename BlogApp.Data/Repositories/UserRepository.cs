using BlogApp.Core.Data;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Repositories
{
    public class UserRepository: DataRepository<UserEntity>, IUserRepository
    {
        public UserRepository(BlogDbContext blogDbContext)
            : base(blogDbContext)
        {

        }
    }
}
