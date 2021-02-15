using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Cartera
{
    [Table("MovimientoDetalle", Schema = "Cartera")]
    public class MovimientoCarDetalle : Util.Auditoria
    {
        [Key]
        public int IdDetalleMov { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDocAfectado { get; set; }

        [Required]
        public int NumDocAfectado { get; set; }

        [Required]
        public decimal ValorCargo { get; set; }

        [Required]
        public decimal ValorOtros { get; set; }

        [Required]
        public decimal ValorReteFuente { get; set; }

        [Required]
        public decimal ValorBase { get; set; }

        [Required]
        public decimal PcMora { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public short DiasMora { get; set; }
    }
}