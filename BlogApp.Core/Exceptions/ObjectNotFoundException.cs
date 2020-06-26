using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BlogApp.Core.Exceptions
{
    public class ObjectNotFoundException : AppException
    {
        public ObjectNotFoundException(string friendlyMessage = null)
            : base((int)HttpStatusCode.NotFound, friendlyMessage)
        {

        }
    }
}
