#region Imports
using MediatR;
using MediatRExamples.Api.Application.Customers.Commands;
using MediatRExamples.Api.Application.Customers.Queries;
using MediatRExamples.Api.Data;
using MediatRExamples.Api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace MediatRExamples.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediatR Examples Api", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            // Register from multiple assembly.
            //services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(ICustomerService).Assembly);


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IRequestHandler<CreateCustomerCommand, Customer>, CreateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCustomerCommand, Customer>, UpdateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetCustomersQuery, List<Customer>>, GetCustomersQueryHandler>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediatR Examples Api v1"));


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
