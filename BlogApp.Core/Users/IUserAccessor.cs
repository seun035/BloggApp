using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Users
{
    public interface IUserAccessor
    {
        Guid GetCurrentUserId();
    }
}
