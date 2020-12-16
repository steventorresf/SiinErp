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
        public virtual DbSet<Ciudades> Ciudades { get; set; }

        public virtual DbSet<Departamentos> Departamentos { get; set; }

        public virtual DbSet<Empresas> Empresas { get; set; }

        public virtual DbSet<Errores> Errores { get; set; }

        public virtual DbSet<Modulos> Modulos { get; set; }

        public virtual DbSet<Paises> Paises { get; set; }

        public virtual DbSet<Parametros> Parametros { get; set; }

        public virtual DbSet<Periodos> Periodos { get; set; }

        public virtual DbSet<Tablas> Tablas { get; set; }

        public virtual DbSet<TablasDetalle> TablasDetalles { get; set; }        

        public virtual DbSet<Terceros> Terceros { get; set; }

        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
        #endregion

        #region Cartera
        public virtual DbSet<Conceptos> Conceptos { get; set; }

        public virtual DbSet<MovimientosCar> MovimientosCar { get; set; }

        public virtual DbSet<MovimientosCarDetalle> MovimientosCarDetalles { get; set; }

        public virtual DbSet<PlazosPago> PlazosPagos { get; set; }
        #endregion

        #region Compras
        public virtual DbSet<Ordenes> Ordenes { get; set; }

        public virtual DbSet<OrdenesDetalle> OrdenesDetalles { get; set; }
        #endregion

        #region Inventario
        public virtual DbSet<Articulos> Articulos { get; set; }

        public virtual DbSet<Existencias> Existencias { get; set; }

        public virtual DbSet<Movimientos> Movimientos { get; set; }

        public virtual DbSet<MovimientosDetalle> MovimientosDetalles { get; set; }

        public virtual DbSet<MovimientosFormasPago> MovimientosFormasPagos { get; set; }

        public virtual DbSet<TiposDoc> TiposDoc { get; set; }
        #endregion

        #region Tesoreria
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<PagosDetalle> PagosDetalle { get; set; }
        #endregion

        #region Ventas
        public virtual DbSet<Caja> Caja { get; set; }

        public virtual DbSet<CajaDetalle> CajaDetalle { get; set; }

        public virtual DbSet<ListaPrecios> ListaPrecios { get; set; }

        public virtual DbSet<ListaPreciosDetalle> ListaPreciosDetalles { get; set; }

        public virtual DbSet<Vendedores> Vendedores { get; set; }
        #endregion

        #region Contabilidad
     
       
        public virtual DbSet<Comprobantes> Comprobantes { get; set; }

        public virtual DbSet<ComprobantesDetalle> ComprobantesDetalles { get; set; }

        public virtual DbSet<PlanDeCuentas> PlanDeCuentas { get; set; }

        public virtual DbSet<Retenciones> Retenciones { get; set; }

        public virtual DbSet<TiposContab> TiposContab { get; set; }



        #endregion
    }
}
