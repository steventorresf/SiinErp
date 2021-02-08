using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("k0claco")]
    public class TipoDocumento
    {
      
        [Key, Column("tip_docu")]
        public string TipoDoc { get; set; }

        [Column("cod_empr")]
        [Required]
        public string IdEmpresa { get; set; }

        [Column("conse_co")]
        [Required]
        public int NumDoc { get; set; }

        [Column("descripc")]
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Column("transaci")]
        [Required]
        public string IdDetTransaccion { get; set; }

      

        [NotMapped]
        public string NomTransaccion { get; set; }

     
        [NotMapped]
        public string NomClaseDoc { get; set; }
    }
}
