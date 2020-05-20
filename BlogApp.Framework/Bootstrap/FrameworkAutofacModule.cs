using Autofac;
using BlogApp.Core.Auths;
using BlogApp.Framework.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Framework.Bootstrap
{
    public class FrameworkAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtGenerator>().As<IJwtGenerator>();

            builder.RegisterAssemblyTypes(GetType().Assembly).Where(c => c.Name.EndsWith("Service")).As(t => t.GetInterfaces().Where(i => i.Name.EndsWith("Service")));
        }
    }
}
