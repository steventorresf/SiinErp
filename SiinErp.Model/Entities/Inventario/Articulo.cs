using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Inventario
{
    [Table("Articulo", Schema = "Inventario")]
    public class Articulo : Common.Auditoria
    {
        [Key]
        public int IdArticulo { get; set; }

        [Required]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string CodArticulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Referencia { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreArticulo { get; set; }

        [Required]
        [StringLength(260)]
        public string NombreBusqueda { get; set; }

        [Required]
        public int IdDetTipoArticulo { get; set; }

        [Required]
        public int IdDetUnidadMed { get; set; }

        [Required]
        public bool EsLinea { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public bool IncluyeIva { get; set; }

        [Required]
        public decimal PcIva { get; set; }

        [Required]
        public decimal StkMin { get; set; }

        [Required]
        public decimal StkMax { get; set; }

        [Required]
        public decimal VrVenta { get; set; }

        [Required]
        public decimal VrCosto { get; set; }

        [Required]
        public decimal Existencia { get; set; }

        [StringLength(1)]
        public string IndCosto { get; set; }

        [StringLength(1)]
        public string IndConsumo { get; set; }

        public DateTimeOffset? FechaUEntrada { get; set; }

        public DateTimeOffset? FechaUSalida { get; set; }

        public DateTimeOffset? FechaUPedida { get; set; }

        [Required]
        public bool AfectaInventario { get; set; }



        [NotMapped]
        public string NombreTipoArticulo { get; set; }

        [NotMapped]
        public string NombreUnidadMed { get; set; }

        [NotMapped]
        public string DescEsLinea { get; set; }

        [NotMapped]
        public bool Sel { get; set; }
    }
}
