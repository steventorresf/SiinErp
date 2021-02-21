using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Contabilidad.Entities;

namespace SiinErp.Models
{
    public class SiinErpContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("SiinErpDbContext"), options => { });
        }

        #region General
        public virtual DbSet<Ciudad> Ciudades { get; set; }

        public virtual DbSet<Departamento> Departamentos { get; set; }

        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<Error> Errores { get; set; }

        public virtual DbSet<Menu> Menu { get; set; }

        public virtual DbSet<MenuUsuario> MenuUsuario { get; set; }

        public virtual DbSet<Modulo> Modulos { get; set; }

        public virtual DbSet<Pais> Paises { get; set; }

        public virtual DbSet<Parametro> Parametros { get; set; }

        public virtual DbSet<Periodo> Periodos { get; set; }

        public virtual DbSet<Tabla> Tablas { get; set; }

        public virtual DbSet<TablaDetalle> TablasDetalles { get; set; }        

        public virtual DbSet<Tercero> Terceros { get; set; }

        public virtual DbSet<TipoDocumento> TiposDocumentos { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        #endregion

        #region Cartera
        public virtual DbSet<Concepto> Conceptos { get; set; }

        public virtual DbSet<MovimientoCar> MovimientosCar { get; set; }

        public virtual DbSet<MovimientoCarDetalle> MovimientosCarDetalles { get; set; }

        public virtual DbSet<PlazoPago> PlazosPagos { get; set; }
        #endregion

        #region Compras
        public virtual DbSet<Orden> Ordenes { get; set; }

        public virtual DbSet<OrdenDetalle> OrdenesDetalles { get; set; }
        #endregion

        #region Inventario
        public virtual DbSet<Articulo> Articulos { get; set; }

        public virtual DbSet<ArticuloExistencia> Existencias { get; set; }

        public virtual DbSet<Movimiento> Movimientos { get; set; }

        public virtual DbSet<MovimientoDetalle> MovimientosDetalles { get; set; }

        public virtual DbSet<MovimientoFormaPago> MovimientosFormasPagos { get; set; }
        #endregion

        #region Tesoreria
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<PagoDetalle> PagosDetalle { get; set; }
        #endregion

        #region Ventas
        public virtual DbSet<Caja> Caja { get; set; }

        public virtual DbSet<CajaDetalle> CajaDetalle { get; set; }

        public virtual DbSet<ListaPrecio> ListaPrecios { get; set; }

        public virtual DbSet<ListaPrecioDetalle> ListaPreciosDetalles { get; set; }

        public virtual DbSet<Vendedor> Vendedores { get; set; }
        #endregion

        #region Contabilidad
     
       
        public virtual DbSet<Comprobante> Comprobantes { get; set; }

        public virtual DbSet<ComprobanteDetalle> ComprobantesDetalles { get; set; }

        public virtual DbSet<PlanDeCuenta> PlanDeCuentas { get; set; }

        public virtual DbSet<Retencion> Retenciones { get; set; }

        public virtual DbSet<TipoContab> TiposContab { get; set; }



        #endregion
    }
}
