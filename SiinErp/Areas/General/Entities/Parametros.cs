using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Parametros", Schema = "General")]
    public class Parametros
    {
        [Key]
        public int IdParametro { get; set; }

        [Required]
        [StringLength(6)]
        public string CodigoParam { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }

        [Required]
        public decimal ValorParam { get; set; }
    }
}
