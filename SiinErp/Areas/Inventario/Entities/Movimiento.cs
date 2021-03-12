using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("Movimiento", Schema = "Inventario")]
    public class Movimiento : Utiles.Auditoria
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

        public int? IdDetCajero { get; set; }

        public int? IdCaja { get; set; }

        public int? IdDetCenCosto { get; set; }

        public int? IdPlazoPago { get; set; }

        public int? IdListaPrecio { get; set; }

        [Required]
        public short Transaccion { get; set; }

        [Required]
        public DateTime FechaDoc { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        public int? IdDetConcepto { get; set; }

        public int? IdTercero { get; set; }

        [StringLength(2)]
        public string TpPago { get; set; }

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

        public int? IdResolucion { get; set; }
      
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        // NotMapped
        [NotMapped]
        public string NoDoc { get; set; }

        [NotMapped]
        public string NombreEmpresa { get; set; }

        [NotMapped]
        public string NitCedula { get; set; }

        [NotMapped]
        public string NombreTercero { get; set; }

        [NotMapped]
        public string TelefonoTercero { get; set; }

        [NotMapped]
        public string DireccionTercero { get; set; }

        [NotMapped]
        public string NombreAlmacen { get; set; }

        [NotMapped]
        public string NombreConcepto { get; set; }

        [NotMapped]
        public string NombreCentroCosto { get; set; }

        [NotMapped]
        public string NombreVendedor { get; set; }

        [NotMapped]
        public decimal VrRestante { get; set; }

        [NotMapped]
        public decimal VrPagar { get; set; }

        [NotMapped]
        public string sFechaFormatted { get; set; }

        [NotMapped]
        public string sFechaVen { get; set; }

        [NotMapped]
        public int DiasVencidos { get; set; }

        [NotMapped]
        public PlazoPago PlazoPago { get; set; }

        [NotMapped]
        public ListaPrecio ListaPrecios { get; set; }

        [NotMapped]
        public List<MovimientoDetalle> ListaDetalle { get; set; }

        public List<MovimientoFormaPago> ListaFormaPago { get; set; }

        // NotMapped Object
        [NotMapped]
        public Empresa Empresa { get; set; }

        [NotMapped]
        public Tercero Tercero { get; set; }

        [NotMapped]
        public Vendedor Vendedor { get; set; }

        [NotMapped]
        public Resolucion Resolucion { get; set; }

    }
}
