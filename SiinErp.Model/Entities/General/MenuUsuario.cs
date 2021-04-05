using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("MenuUsuario", Schema = "General")]
    public class MenuUsuario : Common.Auditoria
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
