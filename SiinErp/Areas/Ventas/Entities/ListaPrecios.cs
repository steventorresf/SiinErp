﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("ListaPrecios", Schema = "Ventas")]
    public class ListaPrecios
    {
        [Key]
        public int IdListaPrecio { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(80)]
        public string NombreLista { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}