﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Entities
{
    [Table("PlazosPago", Schema = "Cartera")]
    public class PlazosPago
    {
        [Key]
        public int IdPlazoPago { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public int Cuotas { get; set; }

        [Required]
        public decimal PcInicial { get; set; }

        [Required]
        public int PlazoDias { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
