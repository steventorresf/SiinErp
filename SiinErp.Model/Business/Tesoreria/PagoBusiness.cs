using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Tesoreria;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Tesoreria;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Tesoreria
{
    public class PagoBusiness : IPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public PagoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Pago> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {

                List<Pago> Lista = (from pa in context.Pagos.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin)
                                    join pr in context.Terceros on pa.IdProveedor equals pr.IdTercero
                                    join co in context.TablasDetalles on pa.IdConcepto equals co.IdDetalle
                                    select new Pago()
                                    {
                                        IdPago = pa.IdPago,
                                        Comentario = pa.Comentario,
                                        IdConcepto = pa.IdConcepto,
                                        CreadoPor = pa.CreadoPor,
                                        Estado = pa.Estado,
                                        FechaCreacion = pa.FechaCreacion,
                                        FechaDoc = pa.FechaDoc,
                                        FechaModificado = pa.FechaModificado,
                                        IdEmpresa = pa.IdEmpresa,
                                        IdProveedor = pa.IdProveedor,
                                        ModificadoPor = pa.ModificadoPor,
                                        NombreProveedor = pr.NombreTercero,
                                        NombreConcepto = co.Descripcion,
                                        NroCheque = pa.NroCheque,
                                        NumDoc = pa.NumDoc,
                                        Periodo = pa.Periodo,
                                        TipoDoc = pa.TipoDoc,
                                        ValorDescuento = pa.ValorDescuento,
                                        ValorTotal = pa.ValorTotal,
                                    }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllPagos", ex.Message, null);
                throw;
            }
        }

        public void Create(Pago entity, List<PagoDetalle> listDetalleFac)
        {
            try
            {
                TipoDocumento tipoDoc = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                tipoDoc.NumDoc++;
                entity.NumDoc = tipoDoc.NumDoc;
                entity.Periodo = entity.FechaDoc.ToString("yyyyMM");
                entity.FechaCreacion = DateTimeOffset.Now;
                context.Pagos.Add(entity);
                context.SaveChanges();
                Pago ob = context.Pagos.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                List<PagoDetalle> listDetalleMov = new List<PagoDetalle>();
                foreach (PagoDetalle f in listDetalleFac)
                {
                    PagoDetalle movdet = new PagoDetalle
                    {
                        IdPago = ob.IdPago,
                        TipoDocAfectado = f.TipoDocAfectado,
                        NumDocAfectado = f.NumDocAfectado,
                        ValorCargo = f.ValorCargo,
                        ValorDscto = f.ValorDscto
                    };
                    listDetalleMov.Add(movdet);
                }
                context.PagosDetalle.AddRange(listDetalleMov);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateMovimientoCar", ex.Message, null);
                throw;
            }
        }
    }
}