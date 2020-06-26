using BlogApp.Core.Comments.Models;
using BlogApp.Core.Replies.Models;
using BlogApp.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.EntityConfigs
{
    public class ReplyEntityConfiguration : IEntityTypeConfiguration<ReplyEntity>
    {
        public void Configure(EntityTypeBuilder<ReplyEntity> builder)
        {
            builder
                .ToTable("Replies")
                .HasOne<CommentEntity>(r => r.Comment)
                .WithMany()
                .HasForeignKey(r => r.CommentId);

            builder
                .HasOne<UserEntity>(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId);
        }
    }
}
