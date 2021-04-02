using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Business.Inventario
{
    public class MovimientoFormaPagoBusiness : IMovimientoFormaPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public MovimientoFormaPagoBusiness(IErrorBusiness _errorBusiness, SiinErpContext _context)
        {
            this.errorBusiness = _errorBusiness;
            this.context = _context;
        }


        public List<MovimientoFormaPago> GetMovimientoFormasPago(int IdMovimiento)
        {
            try
            {
                List<MovimientoFormaPago> Lista = (from mfp in context.MovimientosFormasPagos.Where(x => x.IdMovimiento == IdMovimiento)
                                                   join fp in context.TablasDetalles on mfp.IdDetFormaDePago equals fp.IdDetalle
                                                   join cb in context.TablasDetalles on mfp.IdDetCuenta equals cb.IdDetalle into LeftJoin
                                                   from LF in LeftJoin.DefaultIfEmpty()
                                                   select new MovimientoFormaPago()
                                                   {
                                                       IdMovFormaDePago = mfp.IdMovFormaDePago,
                                                       IdMovimiento = mfp.IdMovimiento,
                                                       IdDetFormaDePago = mfp.IdDetFormaDePago,
                                                       Descripcion = fp.Descripcion,
                                                       IdDetCuenta = mfp.IdDetCuenta,
                                                       DescripcionCuenta = LF == null ? "" : LF.Descripcion,
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
