using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("MenuUsuario", Schema = "General")]
    public class MenuUsuario
    {
        [Key]
        public int IdMenuUsuario { get; set; }

        [Required]
        public int IdMenu { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public Menu Menu { get; set; }
    }
}
