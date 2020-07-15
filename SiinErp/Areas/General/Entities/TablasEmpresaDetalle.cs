using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("TablasEmpresaDetalle", Schema = "General")]
    public class TablasEmpresaDetalle
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdTablaEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public short Orden { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        public DateTimeOffset? FechaModificado { get; set; }

        public int? ModificadoPor { get; set; }
    }
}
