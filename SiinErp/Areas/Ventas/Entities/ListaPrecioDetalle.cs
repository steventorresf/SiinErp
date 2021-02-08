using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("f0lista")]
    public class ListaPrecioDetalle
    {
        [Key, Column("lista_pr", Order = 1)]
        [Required]
        public int IdListaPrecio { get; set; }

        [Key, Column("cod_arti", Order = 2)]
        [Required]
        public string IdArticulo { get; set; }

        [Column("vr_lista")]
        [Required]
        public decimal VrUnitario { get; set; }

        [Column("pc_dsct1")]
        [Required]
        public decimal PcDscto { get; set; }


        [NotMapped]
        public Articulo Articulo { get; set; }
    }
}
