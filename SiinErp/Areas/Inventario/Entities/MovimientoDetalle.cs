using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{

    [Table("i1movi")]
    public class MovimientoDetalle
    {
        [Key, Column("num_movi")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumMovi { get; set; }

        [Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Column("cod_alma")]
        [Required]
        public string CodAlmacen { get; set; }

        [Column("cod_arti")]
        [Required]
        public string CodArticulo { get; set; }

        [Column("transaci")]
        [Required]
        public string Transaci { get; set; }

        [Column("tip_docu")]
        [Required]
        public string TipDocu { get; set; }

        [Column("num_docu")]
        [Required]
        public int NumDocu { get; set; }

        [Column("peri_est")]
        [Required]
        public string Periodo { get; set; }

        [Column("cod_terc")]
        public string CodTercedo { get; set; }

        [Column("fec_movi")]
        [Required]
        public DateTime FecDocu { get; set; }

        [Column("fec_grab")]
        public DateTime FechaProceso { get; set; }

        [Column("num_item")]
        [Required]
        public int NumItem { get; set; }

        [Column("cantidad")]
        [Required]
        public decimal Cantidad { get; set; }

        [Column("pc_dscto")]
        public decimal PDsctoUno { get; set; }

        [Column("pc_impto")]
        public decimal PDsctoDos { get; set; }

        [Column("impto_co")]
        [Required]
        public decimal PIva { get; set; }

        [Column("vr_movim")]
        [Required]
        public decimal VrMovim { get; set; }

        [Column("vr_movid")]
        public decimal? VrMovid { get; set; }

        [Column("vr_costo")]
        [Required]
        public decimal? VrCosto { get; set; }

        [Column("vr_costd")]
        [Required]
        public decimal? VrCostoD { get; set; }

        [Column("existenc")]
        public decimal? Existencia { get; set; }

        [Column("existena")]
        public decimal? ExistenciaA { get; set; }

        [Column("estado_r")]
        [Required]
        public string Estado { get; set; }

        [Column("nro_import")]
        public string NumImportacion { get; set; }

        [Column("num_conten")]
        public string NumContenedor { get; set; }

        [Column("motonave")]
        public string MotoNave { get; set; }

        [Column("cod_maq")]
        public string Identificador { get; set; }

        [Column("tipo_manto")]
        public string TipDocuMantto { get; set; }

        [Column("documento")]
        public string Documento { get; set; }

        [Column("tipdcmnto")]
        public string TipDocuOtro { get; set; }

        [Column("cnum_movi")]
        public int? CNumMovi { get; set; }

        [Column("idcolor")]
        public string IdColor { get; set; }

        [Column("idreferencia")]
        public string IdReferencia { get; set; }

        [Column("cod_tienda")]
        public string EanTercero { get; set; }

        [Column("vendedor")]
        public string Vendedor { get; set; }

        [Column("NumItem")]
        public int? NumItemOtro { get; set; }

        [Column("cod_destino")]
        public string CodAlmDestino { get; set; }






        [NotMapped]
        public Articulo Articulo { get; set; }

    
        [NotMapped]
        public string NombreArticulo { get; set; }

    }
}
