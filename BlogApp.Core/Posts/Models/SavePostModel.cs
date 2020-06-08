using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class SavePostModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public PostStatus Status { get; set; }

        public IList<string> Tags { get; set; }
    }
}
