using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class PostTagEntity: BaseEntity
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }

        public PostEntity Post { get; set; }

        public TagEntity Tag { get; set; }
    }
}
