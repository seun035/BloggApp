using BlogApp.Core.Comments.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Replies.Models;
using BlogApp.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlogApp.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            :base(options)
        {

        }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<ReplyEntity> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
