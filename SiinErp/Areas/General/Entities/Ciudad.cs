using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Ciudad", Schema = "General")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCiudad { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoDane { get; set; }

        [Required]
        public int IdDepartamento { get; set; }
    }
}
