using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Ventas
{
    [Table("Vendedor", Schema = "Ventas")]
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreVendedor { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(80)]
        public string Telefono { get; set; }

        [Required]
        public int IdDetZona { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreZona { get; set; }
    }
}
