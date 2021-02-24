using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Compras
{
    [Table("Orden", Schema = "Compras")]
    public class Orden : Common.Auditoria
    {
        [Key]
        public int IdOrden { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [StringLength(60)]
        public string DireccionDesp { get; set; }

        [Required]
        public int IdPlazoPago { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        public DateTimeOffset FechaVencimiento { get; set; }

        public DateTimeOffset? FechaPago { get; set; }

        [StringLength(200)]
        public string Comentarios { get; set; }

        [Required]
        public decimal PcSeguro { get; set; }

        [Required]
        public decimal ValorNeto { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public decimal ValorDscto { get; set; }

        [Required]
        public decimal ValorBruto { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        [Required]
        public int IdDetOrden { get; set; }

        [Required]
        public int IdDetMoneda { get; set; }

        [Required]
        public int IdDetPrioridad { get; set; }

        [Required]
        public int NumRequisicion { get; set; }

        [Required]
        public int IdDetCenCosto { get; set; }


        [NotMapped]
        public Tercero Proveedor { get; set; }

        [NotMapped]
        public PlazoPago PlazoPago { get; set; }

        [NotMapped]
        public List<OrdenDetalle> ListDetalle { get; set; }
    }
}