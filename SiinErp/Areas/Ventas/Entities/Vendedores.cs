using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("f0vendedor")]
    public class Vendedores
    {
        [Key]
        [Column("vendedor")]
        public string Vendedor { get; set; }


        [Column("nom_vend")]
        [Required]
        [StringLength(100)]
        public string NombreVendedor { get; set; }


        [Column("cod_zona")]
        public string IdDetZona { get; set; }

        [Column("estado")]
        [StringLength(1)]
        public string Estado { get; set; }


    }
}
