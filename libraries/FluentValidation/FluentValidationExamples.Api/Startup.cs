#region Imports
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
#endregion

namespace FluentValidationExamples.Api
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

            // version 11.1 and newer
            services.AddFluentValidationAutoValidation(config =>
            {
                config.ImplicitlyValidateChildProperties = true;
            });

            // In older versions, call services.AddFluentValidation() instead,
            // which is the equivalent of calling services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters()
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            //// Obsolute
            //services.AddFluentValidation(fv =>
            //    {
            //        fv.ImplicitlyValidateChildProperties = true;
            //        fv.ImplicitlyValidateRootCollectionElements = true;
            //        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //        //fv.RegisterValidatorsFromAssemblyContaining<Startup>(); // Other way to register validators
            //    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FluentValidation Examples Api", Version = "v1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluentValidation Examples Api v1"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
