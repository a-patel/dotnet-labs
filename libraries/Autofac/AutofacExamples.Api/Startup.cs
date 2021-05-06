#region Imports
using Autofac;
using AutofacExamples.Api.Infrastructure;
using AutofacExamples.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
#endregion

namespace AutofacExamples.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutofacExamples.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutofacExamples.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        /// <summary>
        /// Configure Container using Autofac: Register Dependency Injection.
        /// This is called AFTER ConfigureServices.
        /// So things you register here OVERRIDE things registered in ConfigureServices.
        /// You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())` in Program.cs
        /// When building the host or this won't be called.
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region WAY-1 (Autofac Module)

            // Add any Autofac modules registrations.
            // Configure related services that provide a subsystem.
            // Package optional application features as ‘plug-ins’.
            // Register a number of similar services that are often used together.
            
            builder.RegisterModule(new MyAutofacModule());
            //builder.RegisterModule(new MyAutofacModule2());
            //builder.RegisterModule(new MyAutofacModule3());

            #endregion


            #region WAY-2 (Direct Registration)

            // Add any services registrations.
            builder.RegisterType<MyService>().As<IService>();

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

            #endregion


            #region Diagnostics

            // If you want to enable diagnostics, you can do that via a build
            // callback. Diagnostics aren't free, so you shouldn't just do this
            // by default. Note: since you're diagnosing the container you can't
            // ALSO resolve the logger to which the diagnostics get written, so
            // writing directly to the log destination is the way to go.
            /*
            var tracer = new DefaultDiagnosticTracer();
            tracer.OperationCompleted += (sender, args) =>
            {
                Console.WriteLine(args.TraceContent);
            };
            builder.RegisterBuildCallback(c =>
            {
                var container = c as IContainer;
                container.SubscribeToDiagnostics(tracer);
            });
            */

            #endregion
        }
    }
}
