using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Utiles
{
    public class Constantes
    {
        // Areas del sistema
        public const string Area_Cartera = "Cartera";
        public const string Area_Compras = "Compras";
        public const string Area_Contabilidad = "Contabilidad";
        public const string Area_General = "General";
        public const string Area_Inventario = "Inventario";
        public const string Area_Nomina = "Nomina";
        public const string Area_Tesoreria = "Tesoreria";
        public const string Area_Ventas = "Ventas";

        // Modulos
        public const string ModuloVentas = "VEN";
        public const string ModuloCompras = "COM";
        public const string ModuloInventario = "INV";

        // Tipos de terceros
        public const string Cliente = "CL";
        public const string Proveedor = "PR";
        public const string Otros = "OT";

        // Estados
        public const string EstadoActivo = "A";
        public const string EstadoInactivo = "I";
        public const string EstadoPendiente = "P";
        public const string EstadoCerrado = "C";

        // ClavePredeterminada
        public const string ClavePredeterminada = "12345";

        // Situacion
        public const string CodSituacion_Abierto = "A";
        public const string CodSituacion_Cerrado = "C";

        // Transacciones
        public const string TransEntrada = "Entrada";
        public const string TransSalida = "Salida";

        // Tipos de documento compra
        public const string ComDocOrdenCompra = "OC";

        // Tipos de documento inventario
        public const string InvDocEntradaOc = "CO";
        public const string InvDocFacturaPuntoVenta = "FA";
        public const string InvDocFacturaVenta = "FC";
        public const string InvDocTraslados = "TB";
        public const string InvDocEntradaTraslado = "ET";

        // Tipos de documento ventas
        public const string VenDocEgresoCaja = "EG";

        // Tablas generales
        public const string TabCajeros = "VenCajeros";
    }
}
