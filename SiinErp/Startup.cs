using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiinErp.Configuration;
using SiinErp.Models;

namespace SiinErp
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
            services.AddControllersWithViews().AddNewtonsoftJson();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(12);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            
            services.AddDbContextInjection(Configuration);
            services.AddBusinessInjection();
            services.AddHttpContextAccessor();
            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDistributedMemoryCache();
            //services.AddWebOptimizer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                //app.UseSpaStaticFiles();
            }
            app.UseCookiePolicy();
            
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default_area",
                    pattern: "{area:exists}/{controller}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "General_default_Tablas",
                    areaName: "General_Tablas",
                    template: "General/{controller=Home}/{action=Tablas}/{id?}");

                routes.MapAreaRoute(
                    name: "areas",
                    areaName: "areas",
                    template: "{area:exists}/{controller=Login}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "areas",
                //    template: "{area:exists}/{controller=Login}/{action=Index}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
