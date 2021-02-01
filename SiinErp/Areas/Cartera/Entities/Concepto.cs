using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Entities
{
    [Table("Concepto", Schema = "Cartera")]
    public class Concepto
    {
        [Key]
        public int IdConcepto { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public int IdTipoDoc { get; set; }

        [Required]
        [StringLength(5)]
        public string CodConcepto { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        [Required]
        public bool AplicaCartera { get; set; }

        [Required]
        public bool AplicaVenta { get; set; }


        [NotMapped]
        public string SAplicaCartera { get; set; }

        [NotMapped]
        public string SAplicaVenta { get; set; }

        [NotMapped]
        public string TipoDoc { get; set; }
    }
}
