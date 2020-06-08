using Autofac;
using AutoMapper;
using BlogApp.Core.Users;
using BlogApp.Data.Bootstrap;
using BlogApp.DomainServices.Bootstrap;
using BlogApp.Framework.Bootstrap;
using BlogApp.UIApiServices.Bootstrap;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.UIApi.Bootstrap
{
    public static class IocConfig
    {
        public static void RegisterDependencies(this ContainerBuilder builder)
        {
            // AutoMapper setup
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UIApiServicesMapperProfile>();
                // cfg.AddProfile<DomainServicesMapperProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            builder.RegisterInstance(mapper).SingleInstance();

            builder.RegisterModule<DataAutofacModule>();
            builder.RegisterModule<FrameworkAutofacModule>();
            builder.RegisterModule<DomainSerrvicesAutofacModule>();
            builder.RegisterModule<UIApiAutofacModule>();

            builder.RegisterType<UserAccessor>().As<IUserAccessor>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}
