using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("FacturasFormasDePago", Schema = "Ventas")]
    public class FacturasFormasDePago
    {
        [Key]
        public int IdFacturaFormaDePago { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdDetFormaDePago { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
