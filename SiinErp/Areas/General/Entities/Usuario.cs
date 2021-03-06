﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("Usuario", Schema = "General")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        public int? UltimoAlmacen { get; set; }


        [NotMapped]
        public string NombreEstado { get; set; }
    }
}
