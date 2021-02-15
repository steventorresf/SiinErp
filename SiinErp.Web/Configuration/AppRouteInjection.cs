using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SiinErp.Web.Configuration
{
    public static class AppRouteInjection
    {
        public static IApplicationBuilder UseMvcInjection(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "Cartera_default",
                    areaName: "Cartera",
                    template: "Cartera/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Compras_default",
                    areaName: "Compras",
                    template: "Compras/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Contabilidad_default",
                    areaName: "Contabilidad",
                    template: "Contabilidad/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "General_default",
                    areaName: "General",
                    template: "General/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Inventario_default",
                    areaName: "Inventario",
                    template: "Inventario/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Tesoreria_default",
                    areaName: "Tesoreria",
                    template: "Tesoreria/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Ventas_default",
                    areaName: "Ventas",
                    template: "Ventas/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}

