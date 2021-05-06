#region Imports
using Autofac;
using AutofacExamples.Api.Services;
#endregion

namespace AutofacExamples.Api.Infrastructure
{
    /// <summary>
    /// Autofac module
    /// Configure related services that provide a subsystem.
    /// Package optional application features as ‘plug-ins’.
    /// Register a number of similar services that are often used together.
    /// </summary>
    public class MyAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<MyService>().As<IService>();

            // Transient
            builder.RegisterType<MyService>().As<IService>()
                .InstancePerDependency();

            // Scoped
            builder.RegisterType<MyService>().As<IService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MyService>().As<IService>()
                .InstancePerRequest();


            // Singleton
            builder.RegisterType<MyService>().As<IService>()
                .SingleInstance();



            //// Scan an assembly for components
            //builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
            //       .Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces();
        }
    }
}
