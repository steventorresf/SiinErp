using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.Compras;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Inventario
{
    public interface IMovimientoBusiness
    {
        void Create(Movimiento entityMov, List<MovimientoDetalle> listDetalleMov);
        void CreateByEntradaCompra(Orden entityOrd, Movimiento entityMov, List<MovimientoDetalle> listaDetalleMov);
        int CreateByPuntoDeVenta(JObject data);
        int UpdateByPuntoDeVenta(JObject data);
        void CreateByFacturaDeVenta(JObject data);
        Movimiento GetByDocumento(JObject data);
        List<Movimiento> GetMovimientosByModificable(int IdEmp);
        List<Movimiento> GetAll(int IdEmp, string Modulo, DateTime FechaIni, DateTime FechaFin);

        //
        List<Movimiento> GetPendientesByTercero(int IdEmpresa, int IdTercero);
        List<Movimiento> GetFacturasByRangoFecha(int IdEmpresa, DateTime FechaIni, DateTime FechaFin);
        void UpdateFactura(Movimiento entity);
        void Anular(int Id);
        int getLastAlmacenByUsu(string nombreUsuario, int IdEmpresa);

        //
        Movimiento Imprimir(int IdMov);

        //
        List<Movimiento> RptAnalisisCartera(int IdEmpresa);
    }
}