using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Entities
{
    [Table("Proveedores", Schema = "Compras")]
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(20)]
        public string NitCedula { get; set; }

        [Required]
        [StringLength(1)]
        public string DgVerificacion { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreProveedor { get; set; }

        [Required]
        public int IdDetTipoProv { get; set; }

        [Required]
        [StringLength(100)]
        public string RepresentanteLegal { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(80)]
        public string Telefono { get; set; }

        public int IdCuentaContable { get; set; }

        [Required]
        public int IdPlazoPago { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        public DateTimeOffset? FechaUltCompra { get; set; }

        public DateTimeOffset? FechaUltPago { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }


        [NotMapped]
        public string NombreTipoProv { get; set; }

        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public PlazosPago PlazoPago { get; set; }

        [NotMapped]
        public int IdDepartamento { get; set; }
    }
}
