using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Abstract
{
    public interface ICajaDetalleBusiness
    {
        List<CajaDetalle> GetCajaDetalleById(int IdCaja);

        void Create(CajaDetalle entity);

        int GetCantidadDetalleCaja(int IdCaja);
    }
}
