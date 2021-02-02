using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiinErp.Model.Entities.Cartera
{
    [Table("Movimiento", Schema = "Cartera")]
    public class MovimientoCar : Util.Auditoria
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
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public decimal ValorIva { get; set; }

        [Required]
        public decimal ValorReteFuente { get; set; }


        [NotMapped]
        public string NombreTercero { get; set; }

        [NotMapped]
        public string NombreConcepto { get; set; }
    }
}