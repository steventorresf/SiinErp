using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("CajaDetalle", Schema = "Ventas")]
    public class CajaDetalle : Utiles.Auditoria
    {
        [Key]
        public int IdCajaDetalle { get; set; }

        [Required]
        public int IdCaja { get; set; }

        public int? IdDetFormaPago { get; set; }

        [Required]
        public int Transaccion { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreFormaPago { get; set; }
    }
}
