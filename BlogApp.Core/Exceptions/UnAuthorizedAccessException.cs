using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BlogApp.Core.Exceptions
{
    public class UnAuthorizedAccessException : AppException
    {
        public UnAuthorizedAccessException(string friendlyMessage = "UnAuthorized access")
            : base((int)HttpStatusCode.Unauthorized, friendlyMessage)
        {

        }
    }
}
