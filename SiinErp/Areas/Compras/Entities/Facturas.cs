using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Entities
{
    [Table("Facturas", Schema = "Compras")]
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string NumFactura { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public int IdPlazoPago { get; set; }

        [Required]
        public short NumeroCuotas { get; set; }

        [Required]
        public decimal PcInteres { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        public DateTimeOffset? FechaVencimiento { get; set; }

        public DateTimeOffset? FechaPago { get; set; }

        [StringLength(50)]
        public string NumRemision { get; set; }

        public int? IdOrden { get; set; }

        [Required]
        public int IdDetCenCosto { get; set; }

        [StringLength(200)]
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
        public decimal ValorFlete { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public decimal ValorDscto { get; set; }

        [Required]
        public decimal ValorOtros { get; set; }

        [Required]
        public decimal ValorBruto { get; set; }

        [Required]
        public decimal ValorPagado { get; set; }

        [Required]
        public decimal ValorNotaCredito { get; set; }

        [Required]
        public decimal ValorNotaDebito { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
