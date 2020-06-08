using Autofac;
using BlogApp.Core.Users;
using BlogApp.DomainServices.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.DomainServices.Bootstrap
{
    public class DomainSerrvicesAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .As(t => t.GetInterfaces().Where(i => i.Name.EndsWith("Service")));

            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(c => c.Name.EndsWith("Manager"))
                .As(t => t.GetInterfaces().Where(i => i.Name.EndsWith("Manager")));

            builder.RegisterType<UserContext>().As<IUserContext>();

        }
    }
}
