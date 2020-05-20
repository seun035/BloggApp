using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Bootstrap
{
    public class DataAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(c => c.Name.EndsWith("Repository"))
                .As(t => t.GetInterfaces().Where(i => i.Name.EndsWith("Repository")));

        }
    }
}
