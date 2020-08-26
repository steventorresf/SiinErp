using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Tesoreria.Entities
{
    [Table("PagosDetalle", Schema = "Tesoreria")]
    public class PagosDetalle
    {
        [Key]
        public int IdDetallePago { get; set; }

        [Required]
        public int IdPago { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDocAfectado { get; set; }

        [Required]
        public int NumDocAfectado { get; set; }

        [Required]
        public decimal ValorCargo { get; set; }

       
        [Required]
        public decimal ValorDscto { get; set; }


    }
}

