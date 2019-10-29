using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TotalBackend.Core.ApplicationService;
using TotalBackend.Core.ApplicationService.Services;
using TotalBackend.Core.DomainService;
using TotalBackend.infrastructure.Data;
using TotalBackend.infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace TotalBackend.RestApi
{
    public class Startup
    {
        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddCors();
            services.AddDbContext<Context>(
                    opt => opt.UseInMemoryDatabase("TotalDB"));
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IIncidentService, IncidentService>();
         

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 3;
            }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<Context>();
   
                }
            }
            else
            {
                app.UseHsts();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<Context>();
                    //dbInitializor.SeedDB(ctx);
                }
            }


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}