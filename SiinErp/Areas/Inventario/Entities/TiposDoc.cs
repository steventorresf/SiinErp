using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("TiposDoc", Schema = "Inventario")]
    public class TiposDoc
    {
        [Key]
        public int IdTipoDoc { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }


        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public int IdDetTransaccion { get; set; }

       
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public string NomTransaccion { get; set; }

        [NotMapped]
        public string NomAlmacen { get; set; }



    }
}
