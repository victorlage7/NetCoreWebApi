using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using WebApi.BUS;
using WebApi.BUS.Interface;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repository;
using WebApi.Repository.BaseRepository;
using WebApi.Repository.Interface;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration _configuration { get;}

        public IWebHostEnvironment _environment { get;}



        public Startup(IConfiguration configuration, IWebHostEnvironment environment) 
        {
            _configuration = configuration;
            _environment = environment;


            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("D:\\Logs\\log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MySQLContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("MySqlConnectionString")));

            //Dependency Injection
            services.AddScoped<IPersonBus, PersonBus>();
            services.AddScoped<IBookBus, BookBus>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                MigratenDatabase(Environment.GetEnvironmentVariable("MySqlConnectionString"));

                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigratenDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "DataBaseMigrations/Migrations", "DataBaseMigrations/Dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database Migration Falied! - " + ex.ToString() , ex);
                throw ex;
            }
        }
    }
}
