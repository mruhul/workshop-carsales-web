using System;
using Autofac;
using Carsales.Web.Infrastructure.Attributes;
using Carsales.Web.Infrastructure.StartUpTasks;

namespace Carsales.Web.Ioc
{
    public class ConventionBasedModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] {typeof (Startup).Assembly};

            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            a.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            Attribute.IsDefined(a, typeof(AutoBindSingletonAttribute)))
                .AsImplementedInterfaces()
                .SingleInstance();


            builder.RegisterAssemblyTypes(assemblies)
                .Where(a => a.IsClass &&
                            Attribute.IsDefined(a, typeof(AutoBindAttribute)))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .AssignableTo<IStartUpTask>()
                .AsImplementedInterfaces();
        }
    }
}