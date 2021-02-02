using System;
using System.ComponentModel.DataAnnotations;

namespace SiinErp.Model.Util
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