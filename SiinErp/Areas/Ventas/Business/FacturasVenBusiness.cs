using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class FacturasVenBusiness
    {
        public int GetLastIdAlmacenPuntoVenta(int idUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                FacturasVen entity = context.FacturasVen.Where(x => x.IdUsuario == idUsuario && x.IdCliente == null)
                                                        .OrderByDescending(x => x.FechaCreacion)
                                                        .FirstOrDefault();
                if (entity != null)
                {
                    return entity.IdDetAlmacen;
                }
                else { return 0; }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetLastIdAlmacenPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public List<FacturasVen> GetPendientesByCli(int IdCliente)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<FacturasVen> Lista = (from f in context.FacturasVen.Where(x => x.IdCliente == IdCliente && x.Estado.Equals(Constantes.EstadoActivo))
                                           select new FacturasVen()
                                           {
                                               IdFactura = f.IdFactura,
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               FechaDoc = f.FechaDoc,
                                               FechaVencimiento = f.FechaVencimiento,
                                               ValorRestante = f.ValorNeto - f.ValorPagado,
                                               ValorPagado = 0,
                                               ValorDscto = 0,
                                               ValorNeto = 0
                                           }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPendientesByCli", ex.Message, null);
                throw;
            }
        }
    }
}
