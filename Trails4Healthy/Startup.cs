﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trails4Healthy.Data;

using Trails4Healthy.Models;
using Trails4Healthy.Services;


using Microsoft.Extensions.Logging;

namespace Trails4Healthy
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
            services.AddDbContext<TrailsUserDBContex>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringTrailsUsers")));

            services.AddTransient<ITrailsRepository, EFTrailsRepository>();
            services.AddDbContext<TrailsDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringTrails")));

            var serviceProvider = services.BuildServiceProvider();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TrailsUserDBContex>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            //
           SeedData.EnsurePopulated(serviceProvider);
           services.AddMvc();

            //Adicionar
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
              //  options.Password.RequireNonAlphanumeric = false;
               // options.Password.RequireUppercase = true;
                //options.Password.RequireLowercase = false;
                //  options.Password.RequiredUniqueChars = 6;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                //    options.Lockout.AllowedForNewUsers = true;
                // User settings
                // options.User.RequireUniqueEmail = true;
            }
                );

            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

         //SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
