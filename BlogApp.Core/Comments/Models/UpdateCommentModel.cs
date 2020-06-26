using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Comments.Models
{
    public class UpdateCommentModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}
