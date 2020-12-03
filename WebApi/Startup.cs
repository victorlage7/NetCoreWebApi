using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebApi.BUS;
using WebApi.BUS.Interface;
using WebApi.Context;
using WebApi.Repository;
using WebApi.Repository.Interface;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<MySQLContext>(options => options.UseMySql(_configuration.GetConnectionString("MySqlConnectionString")));

            services.AddDbContext<MySQLContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("MySqlConnectionString")));

            //Dependency Injection
            services.AddScoped<IPersonBus, PersonBus>();
            services.AddScoped<IPersonRepository, PersonRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });

            //});

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
             
            {
             
                endpoints.MapControllers();
             
            });
        }
    }
}
