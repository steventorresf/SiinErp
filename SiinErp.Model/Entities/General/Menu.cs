using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.General
{
    [Table("Menu", Schema = "General")]
    public class Menu : Common.Auditoria
    {
        [Key]
        public int IdMenu { get; set; }

        [Required]
        [StringLength(15)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [StringLength(15)]
        public string CodPadre { get; set; }

        [Required]
        public short Orden { get; set; }

        [NotMapped]
        public bool Sel { get; set; }

        [NotMapped]
        public List<Menu> ListaMenu { get; set; }
    }
}
