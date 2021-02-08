using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("g0empresa")]
    public class Empresa
    {
        [Key, Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Column("razon_so")]
        [Required]
        public string NombreEmpresa { get; set; }

        [Column("nit_empr")]
        [Required]
        public string Nit { get; set; }

        [Column("cod_ciud")]
        public string CodCiudad { get; set; }

        [Column("multipli")]
        public string DigVerificacion { get; set; }

        [Column("direccio")]
        public string Direccion { get; set; }

        [Column("telefono")]
        [Required]
        public string Telefono { get; set; }

        [Column("CodEan")]
        [Required]
        public string CodEan { get; set; }

        [Column("Representante")]
        public string RepLegal { get; set; }

        [Column("Regimen")]
        [Required]
        public string Regimen { get; set; }

        [Column("fax")]
        [Required]
        public string Fax { get; set; }

        [Column("pais")]
        [Required]
        public string Pais { get; set; }

        [Column("Email")]
        [Required]
        public string Email { get; set; }

        public Empresa()
        {
            CodEmpresa = "NO";
        }
    


        [NotMapped]
        public int IdDepartamento { get; set; }

        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public string NombreRegimen { get; set; }
    }
}
