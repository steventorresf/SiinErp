using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Business
{
    public class MovimientosBusiness
    {
        public void Create(Movimientos entity, List<FacturasVen> listDetalleFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();

                TiposDocumento tipoDoc = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                tipoDoc.NumDoc++;

                entity.NumDoc = tipoDoc.NumDoc;
                entity.Periodo = entity.FechaDoc.ToString("yyyyMM");
                entity.FechaCreacion = DateTimeOffset.Now;

                context.MovimientosCar.Add(entity);
                context.SaveChanges();

                Movimientos ob = context.MovimientosCar.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                List<MovimientosDetalle> listDetalleMov = new List<MovimientosDetalle>();
                foreach(FacturasVen f in listDetalleFac)
                {
                    MovimientosDetalle movdet = new MovimientosDetalle();
                    movdet.IdMovimiento = ob.IdMovimiento;
                    movdet.TipoDocAfectado = f.TipoDoc;
                    movdet.NumDocAfectado = f.NumDoc;
                    movdet.ValorBase = f.ValorPagado;
                    listDetalleMov.Add(movdet);
                }
                context.MovimientosCarDetalles.AddRange(listDetalleMov);
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
