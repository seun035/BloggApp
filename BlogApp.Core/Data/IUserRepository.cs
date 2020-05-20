using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Data
{
    public interface IUserRepository: IDataRepository<UserEntity>
    {
    }
}
