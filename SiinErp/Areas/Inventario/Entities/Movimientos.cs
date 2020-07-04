using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("Movimientos", Schema = "Inventario")]
    public class Movimientos
    {
        [Key]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public int IdDetAlmacen { get; set; }

        [Required]
        public int IdDetCenCosto { get; set; }

        [Required]
        public short Transaccion { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public int IdDetConcepto { get; set; }

        public int? IdTercero { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        public int? IdDetAlmDestino { get; set; }
    }
}
