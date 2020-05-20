using BlogApp.Core.Posts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.EntityConfigs
{
    class PostTagConfiguration : IEntityTypeConfiguration<PostTagEntity>
    {
        public void Configure(EntityTypeBuilder<PostTagEntity> builder)
        {
            builder
                .ToTable("PostTag")
                .HasKey(t => new { t.PostId, t.TagId });

            builder
                .HasOne<PostEntity>(pt => pt.Post)
                .WithMany(p => p.Tags)
                .HasForeignKey(f => f.PostId);

            builder
                .HasOne<TagEntity>(pt => pt.Tag)
                .WithMany(t => t.Posts)
                .HasForeignKey(f => f.TagId);
        }
    }
}
