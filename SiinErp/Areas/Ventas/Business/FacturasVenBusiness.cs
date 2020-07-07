using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
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
    }
}
