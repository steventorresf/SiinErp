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
        public virtual DbSet<Modulos> Modulos { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        public virtual DbSet<Errores> Errores { get; set; }

        public virtual DbSet<Empresas> Empresas { get; set; }

        public virtual DbSet<Tablas> Tablas { get; set; }

        public virtual DbSet<TablasDetalle> TablasDetalles { get; set; }

        public virtual DbSet<Paises> Paises { get; set; }

        public virtual DbSet<Departamentos> Departamentos { get; set; }

        public virtual DbSet<Ciudades> Ciudades { get; set; }

        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

        public virtual DbSet<Periodos> Periodos { get; set; }

        public virtual DbSet<Parametros> Parametros { get; set; }
        #endregion


        #region Cartera
        public virtual DbSet<PlazosPago> PlazosPagos { get; set; }
        #endregion


        #region Compras
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        #endregion


        #region Inventario
        public virtual DbSet<Articulos> Articulos { get; set; }

        public virtual DbSet<TiposDoc> TiposDoc { get; set; }


        #endregion


        #region
        public virtual DbSet<Vendedores> Vendedores { get; set; }

        public virtual DbSet<ListaPrecios> ListaPrecios { get; set; }

        public virtual DbSet<ListaPreciosDetalle> ListaPreciosDetalles { get; set; }

        public virtual DbSet<Clientes> Clientes { get; set; }
        #endregion
    }
}
