using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("Caja", Schema = "Ventas")]
    public class Caja : Utiles.Auditoria
    {
        [Key]
        public int IdCaja { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        public int IdDetCajero { get; set; }

        [Required]
        public int IdTurno { get; set; }

        [Required]
        [StringLength(6)]
        public string Periodo { get; set; }

        [Required]
        public DateTimeOffset FechaDoc { get; set; }

        [Required]
        public decimal SaldoInicial { get; set; }

        [Required]
        public decimal SaldoFinal { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreEmpresa { get; set; }

        [NotMapped]
        public string NombreCaja { get; set; }

        [NotMapped]
        public string NombreTurno { get; set; }

        [NotMapped]
        public string NombreEstado { get; set; }

        [NotMapped]
        public string sFechaDoc { get; set; }

        [NotMapped]
        public List<CajaDetalle> ListaResumen { get; set; }

        [NotMapped]
        public List<CajaDetalle> ListaDetalle { get; set; }
    }
}
