using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.UIApiServices.Posts.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public PostAuthorViewModel Author { get; set; }

        public PostStatus Status { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public DateTime CreatedDateUtc { get; set; }

    }
}
