using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("TipoDocumento", Schema = "General")]
    public class TipoDocumento : Util.Auditoria
    {
        [Key]
        public int IdTipoDoc { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public short IdDetTransaccion { get; set; }

        [Required]
        [StringLength(10)]
        public string CodModulo { get; set; }

        [Required]
        public int IdDetClaseDoc { get; set; }

        public int? IdCuentaDoc { get; set; }

        public int? IdCuentaCargo { get; set; }

        public int? IdCuentaOtro { get; set; }

        public int? IdCuentaReteFuente { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public string NomTransaccion { get; set; }

        [NotMapped]
        public string NombreModulo { get; set; }

        [NotMapped]
        public string NomClaseDoc { get; set; }
    }
}
