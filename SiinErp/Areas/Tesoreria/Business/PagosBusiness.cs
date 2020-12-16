using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Tesoreria.Business
{
    public class PagosBusiness
    {
        public List<Pagos> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Pagos> Lista = (from pa in context.Pagos.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin)
                                     join pr in context.Terceros on pa.IdProveedor equals pr.IdTercero
                                     join co in context.TablasDetalles on pa.IdConcepto equals co.IdDetalle
                                     select new Pagos()
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
                ErroresBusiness.Create("GetAllPagos", ex.Message, null);
                throw;
            }
        }

        public void Create(Pagos entity, List<PagosDetalle> listDetalleFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();

                TiposDocumento tipoDoc = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                tipoDoc.NumDoc++;

                entity.NumDoc = tipoDoc.NumDoc;
                entity.Periodo = entity.FechaDoc.ToString("yyyyMM");
                entity.FechaCreacion = DateTimeOffset.Now;

                context.Pagos.Add(entity);
                context.SaveChanges();

                Pagos ob = context.Pagos.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                List<PagosDetalle> listDetalleMov = new List<PagosDetalle>();

                foreach (PagosDetalle f in listDetalleFac)
                {
                    PagosDetalle movdet = new PagosDetalle();
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
                ErroresBusiness.Create("CreateMovimientoCar", ex.Message, null);
                throw;
            }
        }
    }
}
