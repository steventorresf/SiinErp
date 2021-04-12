using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Resolucion", Schema = "General")]
    public class Resolucion : Utiles.Auditoria
    {
        [Key]
        public int IdResolucion { get; set; }

        [Required]
        [StringLength(50)]
        public string NoResolucion { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int NumeroInicio { get; set; }

        [Required]
        public int NumeroFin { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string sFecha { get; set; }
    }
}
