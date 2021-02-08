using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Entities
{
    [Table("f0nomlista")]
    public class ListaPrecio : Utiles.Auditoria
    {
        
        [Key, Column("lista_pr")]
        public int IdListaPrecio { get; set; }


        [Column("nom_lista")]
        [StringLength(100)]
        public string NombreLista { get; set; }

    }
}
