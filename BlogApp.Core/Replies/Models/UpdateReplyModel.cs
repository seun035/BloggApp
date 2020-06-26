using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Replies.Models
{
    public class UpdateReplyModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}
