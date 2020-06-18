using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("ListaPreciosDetalle", Schema = "Ventas")]
    public class ListaPreciosDetalle
    {
        [Key]
        public int IdDetalleListaPrecio { get; set; }

        [Required]
        public int IdListaPrecio { get; set; }

        [Required]
        public int IdArticulo { get; set; }

        [Required]
        public decimal VrUnitario { get; set; }

        [Required]
        public decimal PcDscto { get; set; }


        [NotMapped]
        public Articulos Articulo { get; set; }
    }
}
