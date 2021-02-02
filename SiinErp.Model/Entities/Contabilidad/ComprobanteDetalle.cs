using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Contabilidad
{
    [Table("ComprobanteDetalle", Schema = "Contabilidad")]
    public class ComprobanteDetalle : Util.Auditoria
    {
        [Key]
        public int IdDetalleComprobante { get; set; }

        [Required]
        public int IdComprobante { get; set; }

        [StringLength(20)]
        public string NoCheque { get; set; }

        [Required]
        [StringLength(100)]
        public string Detalle { get; set; }

        [Required]
        public int IdTercero { get; set; }

        [Required]
        [StringLength(1)]
        public string DebCred { get; set; }

        [Required]
        public int IdCuentaContable { get; set; }

        [Required]
        public int IdDetCenCosto { get; set; }

        public int? IdRetencion { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreTercero { get; set; }

        [NotMapped]
        public string CentroCosto { get; set; }

        [NotMapped]
        public string NombreRetencion { get; set; }

        [NotMapped]
        public string NombreCuenta { get; set; }

        [NotMapped]
        public string Modo { get; set; }
    }
}