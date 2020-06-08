using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Core.Posts.Models
{
    public class Post
    {
        public Post()
        {

        }

        public Post(PostEntity postEntity)
        {
            Id = postEntity.Id;
            Title = postEntity.Title;
            Content = postEntity.Content;
            Author = new User(postEntity.Author);
            Status = postEntity.Status;
            Tags = postEntity.Tags?.Select(t => new Tag(t)).ToList();
            LastModifiedDateUtc = postEntity.LastModifiedDateUtc;
            LastModfiedById = postEntity.LastModfiedById;
            CreatedDateUtc = postEntity.CreatedDateUtc;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        public PostStatus Status { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public DateTime? LastModifiedDateUtc { get; set; }

        public Guid? LastModfiedById { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}
