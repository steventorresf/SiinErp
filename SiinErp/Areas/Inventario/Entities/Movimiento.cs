using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Entities
{
    [Table("f1movc")]
    public class Movimiento
    {
        [Column("cod_empr")]
        [Required]
        public string CodEmpresa { get; set; }

        [Key, Column("tip_docu", Order = 1)]
        [Required]
        public string TipDocu { get; set; }

        [Key, Column("num_docu", Order = 2)]
        [Required]
        public int NumDocu { get; set; }

        [Column("cod_alma")]
        [Required]
        public string CodAlmacen { get; set; }

        [Column("marca_es")]
        public string Marca { get; set; }

        [Column("cod_clie")]
        [Required]
        public string CodClientePadre { get; set; }

        [Column("peri_est")]
        [Required]
        public string Periodo { get; set; }

        [Column("cod_desp")]
        [Required]
        public string CodCliente { get; set; }

        [Column("form_pag")]
        [Required]
        public string FormaPago { get; set; }

        [Column("num_cuot")]
        [Required]
        public Int16 Cuotas { get; set; }

        [Column("porc_ini")]
        public decimal? Porcentaje { get; set; }

        [Column("plazo_in")]
        public Int16? Plazo { get; set; }

        [Column("descanso")]
        public Int16? Descanso { get; set; }

        [Column("fec_proc")]
        [Required]
        public DateTime FechaProceso { get; set; }

        [Column("fec_docu")]
        [Required]
        public DateTime FecDocu { get; set; }

        [Column("fec_venc")]
        [Required]
        public DateTime FecVence { get; set; }

        [Column("fec_remi")]
        public DateTime FecRemision { get; set; }

        [Column("fec_ppag")]
        public DateTime FecPago { get; set; }

        [Column("num_remi")]
        public string NumNotaEntrega { get; set; }

        [Column("num_orde")]
        public string NumPedido { get; set; }

        [Column("num_pedi")]
        public string OrdenCompra { get; set; }

        [Column("vendedor")]
        public string Vendedor { get; set; }

        [Column("letra_co")]
        public decimal? Comision { get; set; }

        [Column("transpor")]
        public string Transportador { get; set; }

        [Column("comenta1")]
        public string Comentarios { get; set; }

        [Column("comenta2")]
        public string Contenido { get; set; }

        [Column("dscto_pp")]
        public decimal? PDsctoFinan { get; set; }

        [Column("dscto_gl")]
        public decimal PDsctoUno { get; set; }

        [Column("pc_segur")]
        public decimal? PIva { get; set; }

        [Column("vr_netof")]
        [Required]
        public decimal ValorNeto { get; set; }

        [Column("vr_segur")]
        [Required]
        public decimal ValorAsegurado { get; set; }

        [Column("vr_flete")]
        [Required]
        public decimal ValorFlete { get; set; }

        [Column("vr_impto")]
        [Required]
        public decimal ValorIva { get; set; }

        [Column("vr_dscto")]
        [Required]
        public decimal ValorDescuento { get; set; }

        [Column("vr_otros")]
        [Required]
        public decimal ValorOtros { get; set; }

        [Column("vr_bruto")]
        [Required]
        public decimal ValorBruto { get; set; }

        [Column("usr_codi")]
        public string Usuario { get; set; }

        [Column("estado_r")]
        public string Estado { get; set; }

        [Column("lista_pr")]
        public Int16? CodLista { get; set; }

        [Column("dscto_pe")]
        public decimal? PDsctoDos { get; set; }

        [Column("vr_pagado")]
        [Required]
        public decimal ValorPagado { get; set; }

        [Column("vr_notacr")]
        [Required]
        public decimal ValorNotaCr { get; set; }

        [Column("vr_notadeb")]
        [Required]
        public decimal ValorNotaDb { get; set; }

        [Column("vr_otrods")]
        [Required]
        public decimal ValorOtroDscto { get; set; }

        [Column("impr")]
        [Required]
        public string Impreso { get; set; }

        [Column("vr_retef")]
        public decimal ValorRetencion { get; set; }







        // NotMapped
        [NotMapped]
        public string NoDoc { get; set; }

        [NotMapped]
        public string NombreEmpresa { get; set; }

        [NotMapped]
        public string NombreTercero { get; set; }

        [NotMapped]
        public string TelefonoTercero { get; set; }

        [NotMapped]
        public string DireccionTercero { get; set; }

        [NotMapped]
        public string NombreAlmacen { get; set; }

        [NotMapped]
        public string NombreConcepto { get; set; }

        [NotMapped]
        public string NombreCentroCosto { get; set; }

        [NotMapped]
        public string NombreVendedor { get; set; }

        [NotMapped]
        public decimal VrPagar { get; set; }

        [NotMapped]
        public string sFechaFormatted { get; set; }

        [NotMapped]
        public string sFechaVen { get; set; }

        [NotMapped]
        public int DiasVencidos { get; set; }

        [NotMapped]
        public PlazoPago PlazoPago { get; set; }

        [NotMapped]
        public ListaPrecio ListaPrecios { get; set; }

        [NotMapped]
        public List<MovimientoDetalle> ListaDetalle { get; set; }

        [NotMapped]
        public int IdCaja { get; set; }

        // NotMapped Object
        [NotMapped]
        public Empresa Empresa { get; set; }

        [NotMapped]
        public Tercero Tercero { get; set; }

       

    }
}
