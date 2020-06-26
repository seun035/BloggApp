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
    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder
                .ToTable("Comments")
                .HasOne<PostEntity>()
                .WithMany()
                .HasForeignKey(c => c.PostId);

            builder
                .HasOne<UserEntity>(u => u.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId);

        }
    }
}
