using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Contabilidad
{
    [Table("Comprobante", Schema = "Contabilidad")]
    public class Comprobante : Util.Auditoria
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


        [NotMapped]
        public string sFechaDoc { get; set; }
    }
}
