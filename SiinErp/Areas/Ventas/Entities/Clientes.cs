using SiinErp.Areas.Cartera.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("Clientes", Schema = "Ventas")]
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(20)]
        public string CodCliente { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string NitCedula { get; set; }

        [StringLength(1)]
        public string DgVerificacion { get; set; }

        [Required]
        public int IdDetTipoCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        [StringLength(100)]
        public string NombreComercial { get; set; }

        [Required]
        [StringLength(80)]
        public string RepresentanteLegal { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(80)]
        public string Telefono { get; set; }

        [Required]
        public int IdDetZona { get; set; }

        [Required]
        public int IdVendedor { get; set; }

        public int? IdCuentaContable { get; set; }

        [Required]
        public bool Credito { get; set; }

        [Required]
        public bool Retencion { get; set; }

        [Required]
        public int IdPlazoPago { get; set; }

        [Required]
        public decimal LimiteCredito { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [Required]
        public int IdPadre { get; set; }

        [Required]
        public int IdListaPrecio { get; set; }

        [Required]
        public bool Iva { get; set; }

        [Required]
        public bool EsCadena { get; set; }

        [Required]
        public decimal PuntosAcumulados { get; set; }

        public DateTimeOffset? FechaUltCompra { get; set; }

        public DateTimeOffset? FechaUltPago { get; set; }

        [Required]
        public bool BaseRetencion { get; set; }

        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }


        [NotMapped]
        public string NombreTipoCliente { get; set; }

        [NotMapped]
        public PlazosPago PlazoPago { get; set; }

        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public int IdDepartamento { get; set; }
    }
}
