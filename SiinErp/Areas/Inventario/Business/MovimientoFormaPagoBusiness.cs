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
    public class MovimientoFormaPagoBusiness : IMovimientoFormaPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public MovimientoFormaPagoBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<MovimientoFormaPago> GetMovimientoFormasPago(int IdMovimiento)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<MovimientoFormaPago> Lista = (from mfp in context.MovimientosFormasPagos.Where(x => x.IdMovimiento == IdMovimiento)
                                                   join fp in context.TablasDetalles on mfp.IdDetFormaDePago equals fp.IdDetalle
                                                   select new MovimientoFormaPago()
                                                   {
                                                       IdMovFormaDePago = mfp.IdMovFormaDePago,
                                                       IdMovimiento = mfp.IdMovimiento,
                                                       IdDetFormaDePago = mfp.IdDetFormaDePago,
                                                       Descripcion = fp.Descripcion,
                                                       Valor = mfp.Valor,
                                                       Orden = fp.Orden,
                                                   }).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
