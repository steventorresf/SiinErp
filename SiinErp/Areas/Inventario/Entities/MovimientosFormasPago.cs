﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("MovimientosFormasPago", Schema = "Inventario")]
    public class MovimientosFormasPago
    {
        [Key]
        public int IdMovFormaDePago { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdDetFormaDePago { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}