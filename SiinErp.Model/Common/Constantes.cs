namespace SiinErp.Model.Common
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

        // Tipos de documento
        public const string TipoDocOrdenCompra = "OC";
        public const string TipoDocEntradaOc = "CO";
        public const string TipoDocFacturaVenta = "FV";
        public const string TipoDocTraslados = "TB";
        public const string TipoDocEntradaTraslado = "ET";

        // Tipos de documento ventas
        public const string VenDocEgresoCaja = "EG";

        // Tablas generales
        public const string TabAlmacen = "InvAlmacen";
        public const string TabCajeros = "VenCajeros";

        public const string APP_POLICY = "SiinErpAppPolicy";

        #region Exception Message Key Constants
        public const string RelatedObjects_Exception_Message = "No es posible eliminar el registro debido a que tiene relaciones.";
        public const string NonObjectFound_Exception_Message = "No se encontró ningún registro con el siguiente Id.";
        public const string NonEqualObject_Exception_Message = "El registro que desea actualizar no corresponde a la información enviada.";
        public const string Duplicated_Exception_Message = "El registro que desea crear ya existe.";
        #endregion

    }
}