using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class Tag
    {
        public Tag()
        {

        }

        public Tag(TagEntity tagEntity)
        {
            Id = tagEntity.Id;
            Name = tagEntity.Name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
