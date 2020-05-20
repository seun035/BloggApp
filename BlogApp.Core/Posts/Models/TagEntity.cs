﻿using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class TagEntity: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<PostTagEntity> Posts { get; set; }
    }
}
