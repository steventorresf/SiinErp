using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Terceros", Schema = "General")]
    public class Terceros
    {
        [Key]
        public int IdTercero { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string NitCedula { get; set; }

        [StringLength(1)]
        public string DgVerificacion { get; set; }

        [Required]
        public int IdDetTipoPersona { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreTercero { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Telefono { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public int IdDepartamento { get; set; }
    }
}
