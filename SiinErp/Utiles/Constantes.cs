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

        // Estados
        public const string EstadoActivo = "A";
        public const string EstadoInactivo = "I";

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
        public const string InvDocFacturaVenta = "FA";
    }
}
