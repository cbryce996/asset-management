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
            // MySql connection string
            var connectionString = "Server=lochnagar.abertay.ac.uk;User=sql2004624;Password=b8DWGSDHEaoB;Database=sql2004624";

            services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();
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
