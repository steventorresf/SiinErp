using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{

    [Table("g0ciudad")]
    public class Ciudad
    {
        [Key, Column("cod_ciud")]
        [Required]
        public string CodCiudad { get; set; }

        [Column("nom_ciud")]
        public string NomCiudad { get; set; }

        [Column("cod_dane")]
        public string CodDane { get; set; }

        [Column("cod_dpto")]
        public string CodDpto { get; set; }

        [Column("nom_ciu_dane")]
        public string NombreDane { get; set; }
    }


}
