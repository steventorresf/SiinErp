using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Ventas
{
    [Table("CajaDetalle", Schema = "Ventas")]
    public class CajaDetalle : Common.Auditoria
    {
        [Key]
        public int IdCajaDetalle { get; set; }

        [Required]
        public int IdCaja { get; set; }

        public int? IdMovimiento { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        public int? IdDetFormaPago { get; set; }

        public int? IdDetCuenta { get; set; }

        [Required]
        public bool Efectivo { get; set; }

        [Required]
        public int Transaccion { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }


        [NotMapped]
        public string NombreFormaPago { get; set; }

        [NotMapped]
        public string NombreCuentaBanco { get; set; }
    }
}
