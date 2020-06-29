using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Business
{
    public class OrdenesDetalleBusiness
    {
        public List<OrdenesDetalle> GetOrdenDetalle(int IdOrden)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<OrdenesDetalle> Lista = (from det in context.OrdenesDetalles.Where(x => x.IdOrden == IdOrden)
                                              join art in context.Articulos on det.IdArticulo equals art.IdArticulo
                                              select new OrdenesDetalle()
                                              {
                                                  IdDetalleOrden = det.IdDetalleOrden,
                                                  IdOrden = det.IdOrden,
                                                  IdArticulo = det.IdArticulo,
                                                  Cantidad = det.Cantidad,
                                                  CantidadEje = det.CantidadEje,
                                                  VrUnitario = det.VrUnitario,
                                                  VrBruto = det.Cantidad * det.VrUnitario,
                                                  PcDscto = det.PcDscto,
                                                  PcIva = det.PcIva,
                                                  VrNeto = (det.Cantidad * det.VrUnitario) - (det.Cantidad * det.VrUnitario * det.PcDscto / 100) + (det.Cantidad * det.VrUnitario * det.PcIva / 100),
                                                  Estado = det.Estado,
                                                  FechaLlegada = det.FechaLlegada,
                                                  FechaPactada = det.FechaPactada,
                                                  Servicio = det.Servicio,
                                                  Articulo = art,
                                              }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetOrdenCompraDetalle", ex.Message, null);
                throw;
            }
        }
    }
}
