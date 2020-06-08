using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class PostQuery: PagedQuery
    {
        public string SearchText { get; set; }

        public PostStatus? Status { get; set; }
    }
}
