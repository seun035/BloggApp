using AutoMapper;
using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users.Models;
using BlogApp.UIApiServices.Comments.ViewModels;
using BlogApp.UIApiServices.Posts.ViewModels;
using BlogApp.UIApiServices.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.UIApiServices.Bootstrap
{
    public class UIApiServicesMapperProfile: Profile
    {
        public UIApiServicesMapperProfile()
        {
            CreateMap<Post, PostViewModel>();

            CreateMap<Comment, CommentViewModel>();

            CreateMap<User, PostAuthorViewModel>();

            CreateMap<User, UserInfoViewModel>();

            CreateMap<User, CommentAuthor>();

            CreateMap<Paged<Post>, Paged<PostViewModel>>();

            CreateMap<Paged<Comment>, Paged<CommentViewModel>>();
        }
    }
}
