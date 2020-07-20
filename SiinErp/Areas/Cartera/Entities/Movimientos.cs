using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Entities
{
    [Table("Movimientos", Schema = "Cartera")]
    public class Movimientos
    {
        [Key]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(5)]
        public string TipoDoc { get; set; }

        [Required]
        public int NumDoc { get; set; }

        [Required]
        public bool AfectaCartera { get; set; }

        [Required]
        public int IdCliente { get; set; }

        public int? IdPadre { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        public int IdVendedor { get; set; }

        [Required]
        public decimal ValorCargo { get; set; }

        [Required]
        public decimal ValorOtros { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public int IdConcepto { get; set; }

        [StringLength(200)]
        public string Comentarios { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public decimal ValorReteFuente { get; set; }
    }
}
