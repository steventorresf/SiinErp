using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Contabilidad
{
    [Table("PlanDeCuenta", Schema = "Contabilidad")]
    public class PlanDeCuenta : Util.Auditoria
    {
        [Key]
        public int IdCuentaContable { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(10)]
        public string CodCuenta { get; set; }

        [Required]
        [StringLength(1)]
        public string NivelCuenta { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCuenta { get; set; }
        
        public int? IdRetencion { get; set; }

        [Required]
        public bool TerceroSN { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}