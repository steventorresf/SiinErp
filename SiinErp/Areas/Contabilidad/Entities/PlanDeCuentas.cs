using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Entities
{
    [Table("PlanDeCuentas", Schema = "Contabilidad")]
    public class PlanDeCuentas
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
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

    }
}