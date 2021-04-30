using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Inventario
{
    [Table("MovimientoDetalle", Schema = "Inventario")]
    public class MovimientoDetalle : Common.Auditoria
    {
        [Key]
        public int IdDetalleMovimiento { get; set; }

        [Required]
        public int IdMovimiento { get; set; }

        [Required]
        public int IdArticulo { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal PcDscto { get; set; }

        [Required]
        public decimal PcIva { get; set; }

        [Required]
        public decimal VrUnitario { get; set; }

        [Required]
        public decimal VrCosto { get; set; }

        [Required]
        public decimal VrBruto { get; set; }

        [Required]
        public decimal VrNeto { get; set; }


        [NotMapped]
        public Articulo Articulo { get; set; }

        [NotMapped]
        public string CodArticulo { get; set; }

        [NotMapped]
        public string NombreArticulo { get; set; }

        [NotMapped]
        public bool IncluyeIva { get; set; }

    }
}
