using AutoMapper;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users.Models;
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

            CreateMap<User, PostAuthorViewModel>();

            CreateMap<User, UserInfoViewModel>();

            CreateMap<Paged<Post>, Paged<PostViewModel>>();
        }
    }
}
