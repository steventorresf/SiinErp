using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Entities
{
    [Table("Empresas", Schema = "General")]
    public class Empresas
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
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string CodEan { get; set; }

        [Required]
        [StringLength(50)]
        public string Representante { get; set; }

        [Required]
        [StringLength(50)]
        public string Regimen { get; set; }
    }
}
