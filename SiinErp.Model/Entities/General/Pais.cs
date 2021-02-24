using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.General
{
    [Table("Pais", Schema = "General")]
    public class Pais : Common.Auditoria
    {
        [Key]
        public int IdPais { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePais { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoDane { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pais comparar && IdPais == comparar.IdPais;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPais);
        }
    }
}