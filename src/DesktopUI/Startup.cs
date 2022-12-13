using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Infrastructure.Persistence;

using ElectronNET.API;
using AssetManagement.Application.Admin;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Http;
using AssetManagement.Application.Auth;
using System.IO;
using System;

namespace AssetManagement.DesktopUI
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
            DotNetEnv.Env.Load();

            string connString = Environment.GetEnvironmentVariable("CONN_STRING");

            // Create DbContext and inject
            services.AddDbContext<ApplicationDbContext>(option => option.UseMySql("Server=lochnagar.abertay.ac.uk;User=sql2004624;Password=b8DWGSDHEaoB;Database=sql2004624", ServerVersion.AutoDetect("Server=lochnagar.abertay.ac.uk;User=sql2004624;Password=b8DWGSDHEaoB;Database=sql2004624")));

            // Inject Application layer services
            services.AddTransient<AdminServices>();
            services.AddTransient<AuthServices>();

            // Inject UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();

            // Inject Cookie Auth
            services.AddAuthentication("Auth").AddCookie("Auth", options => {
                options.Cookie.Name = "Auth";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Task.Run (async () => {
                await Electron.WindowManager.CreateWindowAsync();
            });
        }
    }
}
