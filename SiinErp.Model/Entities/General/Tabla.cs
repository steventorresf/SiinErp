using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Tabla", Schema = "General")]
    public class Tabla
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
    }
}
