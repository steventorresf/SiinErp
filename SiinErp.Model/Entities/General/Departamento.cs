using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Departamento", Schema = "General")]
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreDepartamento { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoDane { get; set; }

        [Required]
        public int IdPais { get; set; }


        [NotMapped]
        public string NombrePais { get; set; }
    }
}
