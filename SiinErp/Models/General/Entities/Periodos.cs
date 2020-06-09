using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Entities
{
    [Table("Periodos", Schema = "General")]
    public class Periodos
    {
        [Key]
        public int IdPeriodo { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(1)]
        public string CodSist { get; set; }

        [Required]
        [StringLength(6)]
        public string PeriodoActual { get; set; }

        [Required]
        public DateTimeOffset FechaInicio { get; set; }

        [Required]
        public DateTimeOffset FechaFin { get; set; }

        [Required]
        [StringLength(6)]
        public string PeriodoAnterior { get; set; }

        [Required]
        [StringLength(6)]
        public string PeriodoSiguiente { get; set; }

        [Required]
        [StringLength(1)]
        public string Situacion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }
    }
}
