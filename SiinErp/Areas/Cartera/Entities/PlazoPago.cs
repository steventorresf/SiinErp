using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Entities
{
    [Table("k5fpago")]
    public class PlazoPago
    {
        [Key, Column("form_pag")]
        public string IdPlazoPago { get; set; }

        [Column("desc_for")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Column("num_cuot")]
        public short Cuotas { get; set; }

        [Column("porc_ini")]
        public decimal? PcInicial { get; set; }

        [Column("plazo_in")]
        public int PlazoDias { get; set; }

    }
}
