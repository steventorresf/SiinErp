﻿using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Tesoreria.Abstract;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Tesoreria.Business
{
    public class PagoBusiness : IPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public PagoBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Pago> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();

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
                    PagoDetalle movdet = new PagoDetalle();
                    movdet.IdPago = ob.IdPago;
                    movdet.TipoDocAfectado = f.TipoDocAfectado;
                    movdet.NumDocAfectado = f.NumDocAfectado;
                    movdet.ValorCargo = f.ValorCargo;
                    movdet.ValorDscto = f.ValorDscto;
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
