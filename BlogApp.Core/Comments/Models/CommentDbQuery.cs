using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Comments.Models
{
    public class CommentDbQuery: PagedQuery
    {
        public Guid PostId { get; set; }

        public Guid? CommentId { get; set; }
    }
}
