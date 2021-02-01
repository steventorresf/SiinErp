using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Periodo", Schema = "General")]
    public class Periodo
    {
        [Key]
        public int IdPeriodo { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(3)]
        public string CodModulo { get; set; }

        [StringLength(6)]
        public string PeriodoAnterior { get; set; }

        [Required]
        [StringLength(6)]
        public string PeriodoActual { get; set; }

        [Required]
        public DateTimeOffset FechaInicio { get; set; }

        [Required]
        public DateTimeOffset FechaFin { get; set; }

        [Required]
        [StringLength(1)]
        public string Situacion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public string NombreModulo { get; set; }
    }
}
