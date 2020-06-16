using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("TablasDetalle", Schema = "General")]
    public class TablasDetalle
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdTabla { get; set; }

        [Required]
        [StringLength(10)]
        public string CodValor { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
