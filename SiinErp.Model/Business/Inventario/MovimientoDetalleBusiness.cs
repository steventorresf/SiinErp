using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Inventario
{
    public class MovimientoDetalleBusiness : IMovimientoDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public MovimientoDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<MovimientoDetalle> GetMovimientosDetalles(int IdMovimiento)
        {
            try
            {
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
                                                     IncluyeIva = ar.IncluyeIva,
                                                     VrCosto = md.VrCosto,
                                                     VrUnitario = md.VrUnitario,
                                                     CodArticulo = ar.CodArticulo,
                                                     NombreArticulo = ar.NombreArticulo,
                                                     Articulo = ar,
                                                 }).OrderBy(x => x.IdDetalleMovimiento).ToList();
                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create(MovimientoDetalle entity)
        {
            try
            {
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