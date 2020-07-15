using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("TablasEmpresa", Schema = "General")]
    public class TablasEmpresa
    {
        [Key]
        public int IdTablaEmpresa { get; set; }

        [Required]
        public int IdTabla { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        public DateTimeOffset? FechaModificado { get; set; }

        public int? ModificadoPor { get; set; }


        [NotMapped]
        public Tablas Tabla { get; set; }

        [NotMapped]
        public Modulos Modulo { get; set; }
    }
}
