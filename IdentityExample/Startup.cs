using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IdentityExample.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseInMemoryDatabase("InMemory");
            });

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireUppercase = false;

                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(configure =>
            {
                configure.Cookie.Name = "Cookie.Auth";
                configure.LoginPath = "/home/login";
            });
            services.AddControllersWithViews();

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(config =>
            {
                config.MapDefaultControllerRoute();
            });
        }
    }
}
