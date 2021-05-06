#region Imports
using AutoMapper;
using AutoMapperExamples.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
#endregion

namespace AutoMapperExamples.Api
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
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<CustomerAutoMapperProfile>();
            //    //cfg.CreateMap<AddressModel, Address>();
            //    //cfg.AddMaps(myAssembly)
            //});

            // Way-1: 
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CustomerAutoMapperProfile>();
                //cfg.CreateMap<AddressModel, Address>(); // other option
            });

            // Way-2: 
            //services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoMapperExamples.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoMapperExamples.Api v1"));

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



// https://github.com/AutoMapper/AutoMapper/blob/master/docs/Configuration.md
