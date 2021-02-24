using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Contabilidad
{
    [Table("Retencion", Schema = "Contabilidad")]
    public class Retencion : Common.Auditoria
    {
        [Key]
        public int IdRetencion { get; set; }

        [Required]
        public int IdEmpresa { get; set; }


        [Required]
        [StringLength(5)]
        public string CodRetencion { get; set; }

       
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Porcentaje { get; set; }


        [Required]
        public decimal BaseRetencion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}