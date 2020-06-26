using BlogApp.Core.Comments.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.EntityConfigs
{
    class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts")
                .HasOne<UserEntity>(p => p.Author)
                .WithMany()
                .HasForeignKey(f => f.AuthorId);

            builder
                .HasMany<CommentEntity>()
                .WithOne(c => c.Post)
                .HasForeignKey(f => f.PostId);

            builder
                .HasMany<TagEntity>(p => p.Tags)
                .WithOne(t => t.Post);
        }
    }
}
