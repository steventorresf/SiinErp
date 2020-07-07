using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("Facturas", Schema = "Ventas")]
    public class FacturasVen
    {
        [Key]
        public int IdFactura { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        public int? IdCliente { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        public int? IdPadre { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public short NumCuotas { get; set; }

        [Required]
        public decimal PcInteres { get; set; }

        [Required]
        public short PlazoDias { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        public DateTimeOffset FechaVencimiento { get; set; }

        public DateTimeOffset? FechaPedido { get; set; }

        public DateTimeOffset? FechaPago { get; set; }

        public int? IdPedido { get; set; }

        public int? IdVendedor { get; set; }

        public int? IdDetTransportador { get; set; }

        public string Comentario { get; set; }

        [Required]
        public decimal PcDsctoProntoPago { get; set; }

        [Required]
        public decimal PcDscto { get; set; }

        [Required]
        public decimal PcSeguro { get; set; }

        [Required]
        public decimal ValorNeto { get; set; }

        [Required]
        public decimal ValorSeguro { get; set; }

        [Required]
        public decimal ValorFletes { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public decimal ValorDscto { get; set; }

        [Required]
        public decimal ValorOtros { get; set; }

        [Required]
        public decimal ValorBruto { get; set; }

        public int? IdListaPrecio { get; set; }

        [Required]
        public decimal ValorPagado { get; set; }

        [Required]
        public decimal ValorNotaCr { get; set; }

        [Required]
        public decimal ValorNotaDb { get; set; }

        [Required]
        public decimal ValorRetefuente { get; set; }

        public string NumGuia { get; set; }

        [Required]
        public int PuntosAcumulados { get; set; }

        [Required]
        public decimal CantArticulos { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
