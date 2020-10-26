using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Entities
{
    [Table("Comprobantes", Schema = "Contabilidad")]
    public class Comprobantes : Utiles.Auditoria
    {
        [Key]
        public int IdComprobante { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
