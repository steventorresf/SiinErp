using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Entities
{

    [Table("k1movi")]
    public class MovimientoCarDetalle
    {
        [Key]
        [Column("num_movi")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumMovi { get; set; }

        [Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Column("tip_docu")]
        [Required]
        public string TipDocu { get; set; }

        [Column("num_docu")]
        [Required]
        public int NumDocu { get; set; }

        [Column("secuenci")]
        [Required]
        public int Secuencia { get; set; }

        [Column("cod_clie")]
        [Required]
        public string CodClientePadre { get; set; }

        [Column("cod_desp")]
        [Required]
        public string CodCliente { get; set; }

        [Column("peri_est")]
        [Required]
        public string Periodo { get; set; }

        [Column("fec_docu")]
        [Required]
        public DateTime FecDocu { get; set; }

        [Column("tipdoc_a")]
        [Required]
        public string TipDocuA { get; set; }

        [Column("numdoc_a")]
        public int NumDocuA { get; set; }

        [Column("num_cuot")]
        public int? NumCuota { get; set; }

        [Column("cod_cobr")]
        public string Vendedor { get; set; }

        [Column("cta_carg")]
        public string CuentaCargo { get; set; }

        [Column("cta_otro")]
        public string CuentaOtro { get; set; }

        [Column("cta_rete")]
        public string CuentaRetef { get; set; }

        [Column("vr_cargo")]
        [Required]
        public decimal VrCargo { get; set; }

        [Column("vr_otros")]
        [Required]
        public decimal VrOtros { get; set; }

        [Column("vr_retef")]
        [Required]
        public decimal VrRetef { get; set; }

        [Column("vr_bcomi")]
        public decimal? VrBase { get; set; }

        [Column("cod_comi")]
        public decimal? Comision { get; set; }

        [Column("saldo_da")]
        public decimal? SaldoDa { get; set; }

        [Column("saldo_cl")]
        public decimal? SaldoCliente { get; set; }

        [Column("usr_codi")]
        public string Usuario { get; set; }

        [Column("fec_proc")]
        [Required]
        public DateTime FechaProceso { get; set; }

        [Column("estad_r")]
        [Required]
        public string Estado { get; set; }

        [Column("dia_mora")]
        public int? DiasMora { get; set; }

        [Column("por_mora")]
        public decimal? PMora { get; set; }

        [Column("snco")]
        public string SNCo { get; set; }

        [Column("impr")]
        public string Impreso { get; set; }

        [Column("vr_iva")]
        public decimal? VrIva { get; set; }

        [Column("vr_retica")]
        public decimal? VrRetIca { get; set; }

        [Column("vr_retpago")]
        public decimal? VrRetPago { get; set; }

        [Column("cod_conc")]
        public string Concepto { get; set; }

        [Column("vr_otroval")]
        public decimal? VrOtroVal { get; set; }

      

    }

}
