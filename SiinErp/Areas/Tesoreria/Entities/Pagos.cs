﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Tesoreria.Entities
{
    [Table("Pagos", Schema = "Tesoreria")]
    public class Pagos
    {
        [Key]
        public int IdPago { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        
        [Required]
        public int IdProveedor { get; set; }

       
        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

      
        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public int IdConcepto { get; set; }

        [StringLength(200)]
        public string Comentario { get; set; }

        [StringLength(200)]
        public string NroCheque { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

      
        [Required]
        public decimal ValorDescuento { get; set; }

    }
}