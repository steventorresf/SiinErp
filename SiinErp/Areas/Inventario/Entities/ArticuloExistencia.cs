using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("i0existenc")]
    public class ArticuloExistencia
    {

        [Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Key, Column("cod_alma", Order = 1)]
        [Required]
        public string CodAlmacen { get; set; }

        [Key, Column("cod_arti", Order = 2)]
        [Required]
        public string CodArticulo { get; set; }

        [Column("existenc")]
        [Required]
        public decimal Existencia { get; set; }

       
    }
}
