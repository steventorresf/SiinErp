using Microsoft.EntityFrameworkCore;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.Compras;
using SiinErp.Model.Entities.Contabilidad;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Entities.Tesoreria;
using SiinErp.Model.Entities.Ventas;

namespace SiinErp.Model.Context
{
    public class SiinErpContext : DbContext
    {
        public SiinErpContext(DbContextOptions<SiinErpContext> options) : base(options)
        {
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
        public virtual DbSet<Resolucion> Resolucion { get; set; }
        public virtual DbSet<Secuencia> Secuencia { get; set; }
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
