using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Entities
{
    [Table("k0clientes")]
    public class Tercero
    {
        [Column("cod_empr")]
        public string CodEmpresa { get; set; }

        [Key, Column("cod_clie")]
        [Required]
        public string CodCliente { get; set; }

        [Column("nit_cedu")]
        public string NitCedula { get; set; }

        [Column("dg_verif")]
        public string DigitoVer { get; set; }

        [Column("tipo_cli")]
        [Required]
        public string TipoCliente { get; set; }

        [Column("nom_clie")]
        [Required]
        public string NombreCliente { get; set; }

        [Column("jef_comp")]
        public string Contacto { get; set; }

        [Column("financie")]
        public string NumFax { get; set; }

        [Column("rep_lega")]
        public string RepLegal { get; set; }

        [Column("direccio")]
        public string Direccion { get; set; }

        [Column("ap_aereo")]
        public string EMail { get; set; }

        [Column("cod_ciud")]
        public string CodCiudad { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("zona_dis")]
        public string Zona { get; set; }

        [Column("vendedor")]
        [Required]
        public string Vendedor { get; set; }

        [Column("cobrador")]
        public string Cobrador { get; set; }

        [Column("cod_cont")]
        public string CodContable { get; set; }

        [Column("sopo_cre")]
        public string SNCredito { get; set; }

        [Column("comp_ret")]
        [Required]
        public string SNRetiene { get; set; }

        [Column("form_pag")]
        [Required]
        public string FormaPago { get; set; }

        [Column("lim_cred")]
        public decimal? CupoCredito { get; set; }

        [Column("acm_comm")]
        public decimal? ComprasMes { get; set; }

        [Column("acm_comp")]
        public decimal? ComprasTotal { get; set; }

        [Column("acm_aant")]
        public decimal? ComprasAnoAnt { get; set; }

        [Column("saldo_cl")]
        public decimal? SaldoCartera { get; set; }

        [Column("fec_ulco")]
        public DateTime? FecUltCompra { get; set; }

        [Column("fec_uped")]
        public DateTime? FecUltPedido { get; set; }

        [Column("fec_ulpa")]
        public DateTime? FecUltPago { get; set; }

        [Column("fec_ingr")]
        public DateTime? FecIngreso { get; set; }

        [Column("estado_r")]
        public string Estado { get; set; }

        [Column("cod_comp")]
        [Required]
        public string CodClientePadre { get; set; }

        [Column("cod_lista")]
        public Int16? ListaPr { get; set; }

        [Column("EanCliente")]
        public string EanCliente { get; set; }

        [Column("BaseRet")]
        [Required]
        public string SNBaseRet { get; set; }

        [Column("iva")]
        [Required]
        public string SNIva { get; set; }

        [Column("Cadena")]
        [Required]
        public string SNCadena { get; set; }

        [Column("RetDiaria")]
        [Required]
        public string SNRetDiaria { get; set; }

        [Column("PuntoDeVenta")]
        public string PuntoDeVEnta { get; set; }

        [Column("cod_alma")]
        public string CodAlmacen { get; set; }

        [Column("Dsc1")]
        [Required]
        public decimal Dsc1 { get; set; }

        [Column("Dsc2")]
        [Required]
        public decimal Dsc2 { get; set; }

        [Column("usr_codi")]
        public string Usuario { get; set; }

        [Column("CLinea")]
        public decimal? CLinea { get; set; }

        [Column("CPropia")]
        public decimal? CPropia { get; set; }

        [Column("CPromo")]
        public decimal? CPromo { get; set; }

        [Column("CNegocios")]
        public decimal? CNegocios { get; set; }

        [Column("CTipoB")]
        public decimal? CTipoB { get; set; }

      


        [NotMapped]
        public string NombreCiudad { get; set; }

        [NotMapped]
        public int IdDepartamento { get; set; }

        [NotMapped]
        public string NombreTipoPersona { get; set; }

        [NotMapped]
        public PlazoPago PlazoPago { get; set; }

        [NotMapped]
        public ListaPrecio ListaPrecios { get; set; }
    }
}
