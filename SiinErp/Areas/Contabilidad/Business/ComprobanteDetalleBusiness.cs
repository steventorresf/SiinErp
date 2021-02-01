using SiinErp.Areas.Contabilidad.Abstract;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class ComprobanteDetalleBusiness : IComprobanteDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ComprobanteDetalleBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<ComprobanteDetalle> GetAll(int IdComprobante)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<ComprobanteDetalle> Lista = (from cd in context.ComprobantesDetalles.Where(x => x.IdComprobante == IdComprobante && x.Estado.Equals(Constantes.EstadoActivo))
                                                   join cc in context.TablasDetalles on cd.IdDetCenCosto equals cc.IdDetalle
                                                   join re in context.Retenciones on cd.IdRetencion equals re.IdRetencion
                                                   join tr in context.Terceros on cd.IdTercero equals tr.IdTercero
                                                   join cu in context.PlanDeCuentas on cd.IdCuentaContable equals cu.IdCuentaContable
                                                   select new ComprobanteDetalle()
                                                   {
                                                       IdDetalleComprobante = cd.IdDetalleComprobante,
                                                       IdComprobante = cd.IdComprobante,
                                                       IdTercero = cd.IdTercero,
                                                       IdDetCenCosto = cd.IdDetCenCosto,
                                                       IdCuentaContable = cd.IdCuentaContable,
                                                       IdRetencion = cd.IdRetencion,
                                                       Detalle = cd.Detalle,
                                                       DebCred = cd.DebCred,
                                                       NoCheque = cd.NoCheque,
                                                       Valor = cd.Valor,
                                                       CentroCosto = cc.Descripcion,
                                                       NombreCuenta = cu.NombreCuenta,
                                                       NombreRetencion = re.Descripcion,
                                                       NombreTercero = tr.NombreTercero,
                                                   }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllComprobantesDetContab", ex.Message, null);
                throw;
            }
        }
    }
}
