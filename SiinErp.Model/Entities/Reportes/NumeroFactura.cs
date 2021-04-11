using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Entities.Reportes
{
    public class NumeroFactura
    {
        public string RazonSocial { get; set; }
        public string NitEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CiudadEmpresa { get; set; }
        public string Representante { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string CodigoCliente { get; set; }
        public string NitCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string CiudadCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string FechaFactura { get; set; }
        public string PlazoPago { get; set; }
        public string FechaVecimiento { get; set; }
        public string DescripcionArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PcIva { get; set; }
        public decimal VrUnitario { get; set; }
        public decimal VrNeto { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorDscto { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorNeto { get; set; }
        public string NoResolucion { get; set; }
        public string FechaResolucion { get; set; }
        public string RangoResolucion { get; set; }
    }
}
