using SiinErp.Areas.General.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Business
{
    public class MovimientosDetalleBusiness
    {
        public List<MovimientosDetalle> GetMovimientosDetalles(int IdMovimiento)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<MovimientosDetalle> Lista = (from md in context.MovimientosDetalles.Where(x => x.IdMovimiento == IdMovimiento)
                                                  join ar in context.Articulos on md.IdArticulo equals ar.IdArticulo
                                                  select new MovimientosDetalle()
                                                  {
                                                      IdDetalleMovimiento = md.IdDetalleMovimiento,
                                                      IdMovimiento = md.IdMovimiento,
                                                      IdArticulo = md.IdArticulo,
                                                      Cantidad = md.Cantidad,
                                                      PcDscto = md.PcDscto,
                                                      PcIva = md.PcIva,
                                                      VrCosto = md.VrCosto,
                                                      VrUnitario = md.VrUnitario,
                                                      CodArticulo = ar.CodArticulo,
                                                      NombreArticulo = ar.NombreArticulo,
                                                      Articulo = ar,
                                                  }).ToList();
                return Lista;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void Create(MovimientosDetalle entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.MovimientosDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoDetalle", ex.Message, null);
                throw;
            }
        }
    }
}
