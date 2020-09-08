using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Utiles
{
    public class Auditoria
    {
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(50)]
        public string CreadoPor { get; set; }

        public DateTimeOffset? FechaModificado { get; set; }

        public string ModificadoPor { get; set; }
    }
}
