﻿// <auto-generated />
using System;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogApp.Data.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("BlogApp.Core.Comments.Models.CommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModfiedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PostId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogApp.Core.Posts.Models.PostEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModfiedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogApp.Core.Posts.Models.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PostId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BlogApp.Core.Replies.Models.ReplyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModfiedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("BlogApp.Core.Users.Models.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("GitHubProfileUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkedInProfileUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.Property<string>("TwitterProfileUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogApp.Core.Comments.Models.CommentEntity", b =>
                {
                    b.HasOne("BlogApp.Core.Users.Models.UserEntity", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApp.Core.Posts.Models.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogApp.Core.Posts.Models.PostEntity", b =>
                {
                    b.HasOne("BlogApp.Core.Users.Models.UserEntity", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogApp.Core.Posts.Models.TagEntity", b =>
                {
                    b.HasOne("BlogApp.Core.Posts.Models.PostEntity", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogApp.Core.Replies.Models.ReplyEntity", b =>
                {
                    b.HasOne("BlogApp.Core.Users.Models.UserEntity", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApp.Core.Comments.Models.CommentEntity", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
