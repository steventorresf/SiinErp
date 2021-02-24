using System;
using System.ComponentModel.DataAnnotations;

namespace SiinErp.Model.Common
{
    public class Auditoria
    {
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(50)]
        public string CreadoPor { get; set; }

        [Required]
        public DateTimeOffset FechaModificado { get; set; }

        [Required]
        [StringLength(50)]
        public string ModificadoPor { get; set; }

        [Required]
        [StringLength(1)]
        public string EstadoFila { get; set; }
    }
}