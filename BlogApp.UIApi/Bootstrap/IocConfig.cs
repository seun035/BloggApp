using Autofac;
using BlogApp.Data.Bootstrap;
using BlogApp.Framework.Bootstrap;
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
            builder.RegisterModule<DataAutofacModule>();
            builder.RegisterModule<FrameworkAutofacModule>();
        }
    }
}
