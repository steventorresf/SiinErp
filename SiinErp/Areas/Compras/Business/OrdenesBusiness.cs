using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Business
{
    public class OrdenesBusiness
    {
        public void Create(Ordenes entity, List<OrdenesDetalle> entityDet)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.Ordenes.Add(entity);
                context.SaveChanges();

                Ordenes orden = context.Ordenes.FirstOrDefault(x => x.NumDoc == 0 && x.TipoDoc.Equals(""));
                foreach(OrdenesDetalle det in entityDet)
                {
                    det.IdOrden = orden.IdOrden;
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateOrdenCompra", ex.Message, null);
                throw;
            }
        }
    }
}
