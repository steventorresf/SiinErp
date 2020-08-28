using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("Movimientos", Schema = "Inventario")]
    public class Movimientos : Utiles.Auditoria
    {
        [Key]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(3)]
        public string CodModulo { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        public int? IdDetCenCosto { get; set; }

        [Required]
        public short Transaccion { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        public DateTimeOffset FechaVencimiento { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public int IdDetConcepto { get; set; }

        public int? IdTercero { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }

        public int? IdDetAlmDestino { get; set; }

        public string NumFactura { get; set; }

        public string NumRemision { get; set; }

        public int? IdOrden { get; set; }

        public int? IdPedido { get; set; }

        public int? IdVendedor { get; set; }

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
        public decimal ValorSaldo { get; set; }

      
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }



        [NotMapped]
        public string NombreTercero { get; set; }

        [NotMapped]
        public string NombreAlmacen { get; set; }

        [NotMapped]
        public decimal VrPagar { get; set; }

        [NotMapped]
        public string sFechaFormatted { get; set; }

    }
}
