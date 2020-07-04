using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("MovimientosDetalle", Schema = "Inventario")]
    public class MovimientosDetalle
    {
        [Key]
        public int IdDetalleMovimiento { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdArticulo { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal PcDscto { get; set; }

        [Required]
        public decimal PcIva { get; set; }

        [Required]
        public decimal VrUnitario { get; set; }

        [Required]
        public decimal VrCosto { get; set; }
    }
}
