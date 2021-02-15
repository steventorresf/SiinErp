using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Inventario
{
    [Table("ArticuloExistencia", Schema = "Inventario")]
    public class ArticuloExistencia : Util.Auditoria
    {
        [Key]
        public int IdExistencia { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        [Required]
        public int IdArticulo { get; set; }

        [Required]
        public decimal Existencia { get; set; }

        [StringLength(50)]
        public string Ubicacion { get; set; }
    }
}
