using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Cartera
{
    [Table("Concepto", Schema = "Cartera")]
    public class Concepto : Common.Auditoria
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
