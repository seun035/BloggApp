using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public enum PostStatus
    {
        None = 0,
        Draft = 1,
        RequestPublish = 2,
        Published = 3,
        Deleted = 4
    }
}
