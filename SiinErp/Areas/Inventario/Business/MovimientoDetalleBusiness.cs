using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Inventario.Abstract;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Business
{
    public class MovimientoDetalleBusiness : IMovimientoDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public MovimientoDetalleBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<MovimientoDetalle> GetMovimientosDetalles(int IdMovimiento)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<MovimientoDetalle> Lista = (from md in context.MovimientosDetalles.Where(x => x.IdMovimiento == IdMovimiento)
                                                  join ar in context.Articulos on md.IdArticulo equals ar.IdArticulo
                                                  select new MovimientoDetalle()
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

        public void Create(MovimientoDetalle entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.MovimientosDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateMovimientoDetalle", ex.Message, null);
                throw;
            }
        }
    }
}
