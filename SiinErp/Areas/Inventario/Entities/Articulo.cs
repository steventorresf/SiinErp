using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("i0articulos")]
    public class Articulo
    {
        [Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Key, Column("cod_arti")]
        [Required]
        public string CodArticulo { get; set; }

        [Column("referenc")]
        public string IdReferencia { get; set; }

        [Column("tipo_inv")]
        public string TipoInv { get; set; }

        [Column("cc_linea")]
        public string Linea { get; set; }

        [Column("sb_linea")]
        public string SubLinea { get; set; }

        [Column("clase_ar")]
        public string Clase { get; set; }

        [Column("grupo_co")]
        [Required]
        public string Grupo { get; set; }

        [Column("nom_arti")]
        [Required]
        public string NombreArticulo { get; set; }

        [Column("und_desc")]
        public string UniMed { get; set; }

        [Column("und_empa")]
        public Int16? UniEmpaque { get; set; }

        [Column("peso_und")]
        public decimal? Peso { get; set; }

        [Column("ind_movi")]
        public string IndCosto { get; set; }

        [Column("pg_dscto")]
        public string PgDscto { get; set; }

        [Column("pc_dscto")]
        public decimal? PcDscto { get; set; }

        [Column("pc_impto")]
        public decimal? PcImpto { get; set; }

        [Column("impto_co")]
        public decimal? ImptoCo { get; set; }

        [Column("tmp_repo")]
        public Int16? TiempoRep { get; set; }

        [Column("eco_cant")]
        public decimal? EcoCantidad { get; set; }

        [Column("dem_diar")]
        public decimal? StkSeguridad { get; set; }

        [Column("stk_mini")]
        public int? StkMinimo { get; set; }

        [Column("stk_maxi")]
        public int? StkMaximo { get; set; }

        [Column("fact_imp")]
        public decimal? FactImp { get; set; }

        [Column("por_aran")]
        public decimal? PcArancel { get; set; }

        [Column("vr_venta")]
        public decimal? ValorVenta { get; set; }

        [Column("vr_vsuge")]
        public decimal? ValorCompra { get; set; }

        [Column("vr_costo")]
        public decimal? CostoUnit { get; set; }

        [Column("vr_acosp")]
        public decimal? ValorAcosp { get; set; }

        [Column("vr_acosd")]
        public decimal? ValorAcosd { get; set; }

        [Column("vr_tcosp")]
        public decimal? ValorTcosp { get; set; }

        [Column("vr_tcosd")]
        public decimal? ValorTcosd { get; set; }

        [Column("existenc")]
        public decimal? Existencia { get; set; }

        [Column("f_uentra")]
        public DateTime? FecUltEntra { get; set; }

        [Column("f_usalid")]
        public DateTime? FecUltSalida { get; set; }

        [Column("acm_sali")]
        public decimal? AcumSalida { get; set; }

        [Column("acm_devo")]
        public decimal? AcumDevolucion { get; set; }

        [Column("acm_aant")]
        public decimal? AcumAnt { get; set; }

        [Column("fila_rep")]
        public Int16? FilaRep { get; set; }

        [Column("culu_rep")]
        public Int16? CuluRep { get; set; }

        [Column("fec_crea")]
        public DateTime? FecGraba { get; set; }

        [Column("estado_r")]
        [Required]
        public string Estado { get; set; }

        [Column("refe_int")]
        public string RefInterna { get; set; }

        [Column("idcolor")]
        public string IdColor { get; set; }

        [Column("alto")]
        public decimal? Altura { get; set; }

        [Column("largo")]
        public decimal? Longitud { get; set; }

        [Column("ancho")]
        public decimal? Ancho { get; set; }

        [Column("snlinea")]
        public string SNLinea { get; set; }

        [Column("num_movi")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? NumMovi { get; set; }


        [Column("usr_codi")]
        public string Usuario { get; set; }

      
        [Column("TipoComi")]
        public string TipoComision { get; set; }

        [Column("f_pentra")]
        public DateTime? FecPrimeraEnt { get; set; }

      
      
    }
}
