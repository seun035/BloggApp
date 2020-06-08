using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.UIApiServices.Bootstrap
{
    public class UIApiAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .As(t => t.GetInterfaces()
                .Where(i => i.Name.EndsWith("Service")));


        }
    }
}
