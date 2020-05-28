using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Entities
{
    [Table("Errores", Schema = "General")]
    public class Errores
    {
        [Key]
        public int IdError { get; set; }

        [Required]
        [StringLength(50)]
        public string Metodo { get; set; }

        [Required]
        [StringLength(500)]
        public string MensajeError { get; set; }

        [Required]
        public DateTimeOffset FechaError { get; set; }

        [Required]
        public int? IdUsuario { get; set; }
    }
}
