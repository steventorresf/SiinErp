using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Secuencia", Schema = "General")]
    public class Secuencia : Utiles.Auditoria
    {
        [Key]
        public int IdSecuencia { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string Prefijo { get; set; }

        [Required]
        public int NoSecuencia { get; set; }

        [Required]
        public int Longitud { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
