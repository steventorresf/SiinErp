using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiinErp.Desktop.Forms.Ventas;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Business.General;
using SiinErp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private static IServiceProvider serviceProvider { get; set; }


        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            //Application.Run(new FormHome());
            Application.Run(serviceProvider.GetRequiredService<FormHome>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //services.AddDbContext<SiinErpContext>(options => options.UseSqlServer(configuration.GetConnectionString("SiinErpDbContext")));
            services.AddDbContext<SiinErpContext>(options => options.UseSqlServer("Data Source=(local);Initial Catalog=SiinErpComercia;Integrated Security=True"));
            services.AddScoped<FormHome>();
            services.AddScoped<Controllers.IControllerBusiness, Controllers.ControllerBusiness>();

            #region Cartera Injection
            services.AddScoped<Model.Abstract.Cartera.IConceptoBusiness, Model.Business.Cartera.ConceptoBusiness>();
            services.AddScoped<Model.Abstract.Cartera.IMovimientoCarBusiness, Model.Business.Cartera.MovimientoCarBusiness>();
            services.AddScoped<Model.Abstract.Cartera.IPlazoPagoBusiness, Model.Business.Cartera.PlazoPagoBusiness>();
            #endregion

            #region Compras Injection
            services.AddScoped<Model.Abstract.Compras.IOrdenBusiness, Model.Business.Compras.OrdenBusiness>();
            services.AddScoped<Model.Abstract.Compras.IOrdenDetalleBusiness, Model.Business.Compras.OrdenDetalleBusiness>();
            #endregion

            #region Contabilidad Injection
            services.AddScoped<Model.Abstract.Contabilidad.IComprobanteBusiness, Model.Business.Contabilidad.ComprobanteBusiness>();
            services.AddScoped<Model.Abstract.Contabilidad.IComprobanteDetalleBusiness, Model.Business.Contabilidad.ComprobanteDetalleBusiness>();
            services.AddScoped<Model.Abstract.Contabilidad.IPlanDeCuentaBusiness, Model.Business.Contabilidad.PlanDeCuentaBusiness>();
            services.AddScoped<Model.Abstract.Contabilidad.IRetencionBusiness, Model.Business.Contabilidad.RetencionBusiness>();
            services.AddScoped<Model.Abstract.Contabilidad.ITipoContabBusiness, Model.Business.Contabilidad.TipoContabBusiness>();
            #endregion

            #region General Injection
            services.AddScoped<Model.Abstract.General.ICiudadBusiness, Model.Business.General.CiudadBusiness>();
            services.AddScoped<Model.Abstract.General.IDepartamentoBusiness, Model.Business.General.DepartamentoBusiness>();
            services.AddScoped<Model.Abstract.General.IEmpresaBusiness, Model.Business.General.EmpresaBusiness>();
            services.AddScoped<Model.Abstract.General.IErrorBusiness, Model.Business.General.ErrorBusiness>();
            services.AddScoped<Model.Abstract.General.IModuloBusiness, Model.Business.General.ModuloBusiness>();
            services.AddScoped<Model.Abstract.General.IPaisBusiness, Model.Business.General.PaisBusiness>();
            services.AddScoped<Model.Abstract.General.IParametroBusiness, Model.Business.General.ParametroBusiness>();
            services.AddScoped<Model.Abstract.General.IPeriodoBusiness, Model.Business.General.PeriodoBusiness>();
            services.AddScoped<Model.Abstract.General.ITablaBusiness, Model.Business.General.TablaBusiness>();
            services.AddScoped<Model.Abstract.General.ITablaDetalleBusiness, Model.Business.General.TablaDetalleBusiness>();
            services.AddScoped<Model.Abstract.General.ITerceroBusiness, Model.Business.General.TerceroBusiness>();
            services.AddScoped<Model.Abstract.General.ITipoDocumentoBusiness, Model.Business.General.TipoDocumentoBusiness>();
            services.AddScoped<Model.Abstract.General.IUsuarioBusiness, Model.Business.General.UsuarioBusiness>();
            #endregion

            #region Inventario Injection
            services.AddScoped<Model.Abstract.Inventario.IArticuloBusiness, Model.Business.Inventario.ArticuloBusiness>();
            services.AddScoped<Model.Abstract.Inventario.IMovimientoBusiness, Model.Business.Inventario.MovimientoBusiness>();
            services.AddScoped<Model.Abstract.Inventario.IMovimientoDetalleBusiness, Model.Business.Inventario.MovimientoDetalleBusiness>();
            services.AddScoped<Model.Abstract.Inventario.IMovimientoFormaPagoBusiness, Model.Business.Inventario.MovimientoFormaPagoBusiness>();
            #endregion

            #region Tesoreria Injection
            services.AddScoped<Model.Abstract.Tesoreria.IPagoBusiness, Model.Business.Tesoreria.PagoBusiness>();
            #endregion

            #region Ventas Injection
            services.AddScoped<Model.Abstract.Ventas.ICajaBusiness, Model.Business.Ventas.CajaBusiness>();
            services.AddScoped<Model.Abstract.Ventas.ICajaDetalleBusiness, Model.Business.Ventas.CajaDetalleBusiness>();
            services.AddScoped<Model.Abstract.Ventas.IListaPrecioBusiness, Model.Business.Ventas.ListaPrecioBusiness>();
            services.AddScoped<Model.Abstract.Ventas.IListaPrecioDetalleBusiness, Model.Business.Ventas.ListaPrecioDetalleBusiness>();
            services.AddScoped<Model.Abstract.Ventas.IVendedorBusiness, Model.Business.Ventas.VendedorBusiness>();
            #endregion
        }

    }
}
