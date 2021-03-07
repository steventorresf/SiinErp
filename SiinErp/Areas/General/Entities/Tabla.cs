using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Tabla", Schema = "General")]
    public class Tabla : Utiles.Auditoria
    {
        [Key]
        public int IdTabla { get; set; }

        [Required]
        [StringLength(15)]
        public string CodTabla { get; set; }

        [Required]
        [StringLength(10)]
        public string CodModulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public bool Visible { get; set; }
    }
}
