using BlogApp.Core.Posts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.EntityConfigs
{
    class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.ToTable("Tags")
                .HasMany<PostTagEntity>(t => t.Posts)
                .WithOne(pt => pt.Tag);
        }
    }
}
