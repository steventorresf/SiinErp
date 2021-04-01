using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Cartera
{
    [Table("PlazoPago", Schema = "Cartera")]
    public class PlazoPago : Common.Auditoria
    {
        [Key]
        public int IdPlazoPago { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public short Cuotas { get; set; }

        [Required]
        public decimal PcInicial { get; set; }

        [Required]
        public int PlazoDias { get; set; }
    }
}