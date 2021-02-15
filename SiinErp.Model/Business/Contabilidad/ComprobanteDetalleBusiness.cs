using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Contabilidad;
using SiinErp.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Contabilidad
{
    public class ComprobanteDetalleBusiness : IComprobanteDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ComprobanteDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<ComprobanteDetalle> GetAll(int IdComprobante)
        {
            try
            {
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