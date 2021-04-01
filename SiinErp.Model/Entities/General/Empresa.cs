using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Empresa", Schema = "General")]
    public class Empresa : Common.Auditoria
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(20)]
        public string NitEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(150)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [StringLength(50)]
        public string CodEan { get; set; }

        [Required]
        [StringLength(50)]
        public string Representante { get; set; }

        [Required]
        public int IdDetRegimen { get; set; }


        [NotMapped]
        public string NombreRegimen { get; set; }
    }
}
