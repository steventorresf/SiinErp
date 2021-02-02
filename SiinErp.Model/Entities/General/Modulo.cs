using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Modulo", Schema = "General")]
    public class Modulo
    {
        [Key]
        [StringLength(10)]
        public string CodModulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Periodo { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }
    }
}
