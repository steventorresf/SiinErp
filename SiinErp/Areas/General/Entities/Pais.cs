﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Pais", Schema = "General")]
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePais { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoDane { get; set; }
    }
}
