using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Entities
{
    [Table("Tablas", Schema = "General")]
    public class Tablas
    {
        [Key]
        [StringLength(10)]
        public string CodTabla { get; set; }

        [Required]
        [StringLength(10)]
        public string CodModulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public string NombreModulo { get; set; }
    }
}
