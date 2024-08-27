using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelInfrastructure.Data;
using HotelApplication.Services;
using HotelApplication.Services.BaseServices;
using HotelDomain.IRepositories;
using HotelInfrastructure.Repositories;
using HotelApplication.Logging;
using Serilog;
using System.IO;
using HotelDomain.IRepositories.IBaseRepositories;


namespace HotelApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var logderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            // Serilog konfigürasyonu
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(Path.Combine(logderPath, "logs.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                );
            });


            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IReservedRepository, ReservedRepository>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IReservedService, ReservedService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelApi", Version = "v1" });
            });

            services.AddControllersWithViews();
            services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowReactApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var checkDbConnection = new CheckDbConnection(connectionString);
            checkDbConnection.CheckConnectionAsync().GetAwaiter().GetResult();
        }
    }
}
