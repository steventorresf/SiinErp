using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.General
{
    [Table("Ciudad", Schema = "General")]
    public class Ciudad : Common.Auditoria
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