﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Ventas
{
    [Table("ListaPrecio", Schema = "Ventas")]
    public class ListaPrecio : Common.Auditoria
    {
        [Key]
        public int IdListaPrecio { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreLista { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
