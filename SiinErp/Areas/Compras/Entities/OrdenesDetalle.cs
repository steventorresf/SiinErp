using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Entities
{
    [Table("OrdenesDetalle", Schema = "Compras")]
    public class OrdenesDetalle
    {
        [Key]
        public int IdDetalleOrden { get; set; }

        [Required]
        public int IdOrden { get; set; }

        [Required]
        public int IdArticulo { get; set; }

        [Required]
        public decimal VrUnitario { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal CantidadEje { get; set; }

        [Required]
        public decimal PcDscto { get; set; }

        [Required]
        public decimal PcIva { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public DateTimeOffset FechaPactada { get; set; }

        public DateTimeOffset? FechaLlegada { get; set; }

        [StringLength(500)]
        public string Servicio { get; set; }


        [NotMapped]
        public decimal VrBruto { get; set; }

        [NotMapped]
        public decimal VrNeto { get; set; }

        [NotMapped]
        public Articulos Articulo { get; set; }
    }
}
