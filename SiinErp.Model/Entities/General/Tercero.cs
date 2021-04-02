using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Tercero", Schema = "General")]
    public class Tercero : Common.Auditoria
    {
        [Key]
        public int IdTercero { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoTercero { get; set; }

        [Required]
        [StringLength(50)]
        public string NitCedula { get; set; }

        [StringLength(1)]
        public string DgVerificacion { get; set; }

        [Required]
        public int IdDetTipoPersona { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreTercero { get; set; }

        [Required]
        [StringLength(300)]
        public string NombreBusqueda { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? IdCuentaContable { get; set; }

        public int? IdPlazoPago { get; set; }

        public int? IdDetZona { get; set; }

        public int? IdVendedor { get; set; }

        [Required]
        public decimal LimiteCredito { get; set; }

        public int? IdPadre { get; set; }

        public int? IdListaPrecio { get; set; }

        [Required]
        public bool Iva { get; set; }



        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public int IdDepartamento { get; set; }

        [NotMapped]
        public string NombreTipoPersona { get; set; }

        [NotMapped]
        public PlazoPago PlazoPago { get; set; }

        [NotMapped]
        public ListaPrecio ListaPrecios { get; set; }

        [NotMapped]
        public bool Sel { get; set; }
    }
}
