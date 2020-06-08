using BlogApp.Core.Framework;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data
{
    public static class Seed
    {
        public static void SeedDatabase(BlogDbContext blogDbContext, ICryptoService cryptoService)
        {
            var salt = cryptoService.GenerateSalt(32);
            var passwordHash = cryptoService.HashPasswordKeyDerivationPbkdf2("password", salt);

            var user1 = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "User1",
                LastName = "User11",
                Email = "user1@example.com",
                Salt = salt,
                Password = passwordHash,
                CreatedDateUtc = DateTime.UtcNow
            };

            var user2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "User2",
                LastName = "User22",
                Email = "user2@example.com",
                Salt = salt,
                Password = passwordHash,
                CreatedDateUtc = DateTime.UtcNow
            };

            var user1post1 = new PostEntity
            {
                Id = Guid.NewGuid(),
                Title = "user1 post1",
                Status = PostStatus.Draft,
                AuthorId = user1.Id,
                Content = "user1 post1 content",
                CreatedDateUtc = DateTime.UtcNow, 
            };

            var user1post2 = new PostEntity
            {
                Id = Guid.NewGuid(),
                Title = "user1 post2",
                Status = PostStatus.Published,
                AuthorId = user1.Id,
                Content = "user1 post2 content",
                CreatedDateUtc = DateTime.UtcNow,
            };

            var user2post1 = new PostEntity
            {
                Id = Guid.NewGuid(),
                Title = "user2 post1",
                Status = PostStatus.Draft,
                AuthorId = user2.Id,
                Content = "user2 post1 content",
                CreatedDateUtc = DateTime.UtcNow,

            };

            var user2post2 = new PostEntity
            {
                Id = Guid.NewGuid(),
                Title = "user2 post2",
                Status = PostStatus.Published,
                AuthorId = user2.Id,
                Content = "user2 post2 content",
                CreatedDateUtc = DateTime.UtcNow,

            };

            var tag1 = new TagEntity
            {
                Id = Guid.NewGuid(),
                Name = "Tag 1",
                PostId = user1post1.Id
            };

            var tag2 = new TagEntity
            {
                Id = Guid.NewGuid(),
                Name = "Tag 2",
                PostId = user1post2.Id
            };

            var tag3 = new TagEntity
            {
                Id = Guid.NewGuid(),
                Name = "Tag 3",
                PostId = user2post1.Id
            };

            var tag4 = new TagEntity
            {
                Id = Guid.NewGuid(),
                Name = "Tag 4",
                PostId = user2post2.Id
            };

            if (!blogDbContext.Users.Any())
            {
                blogDbContext.Users.AddRange(user1, user2);
            }

            if (!blogDbContext.Posts.Any())
            {
                blogDbContext.Posts.AddRange(user1post1, user1post2, user2post1, user2post2);
            }

            if (!blogDbContext.Tags.Any())
            {
                blogDbContext.Tags.AddRange(tag1, tag2, tag3, tag4);
            }

            blogDbContext.SaveChanges();
        }
    }
}
