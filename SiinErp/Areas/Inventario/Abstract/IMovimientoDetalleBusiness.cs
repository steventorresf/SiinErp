using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Abstract
{
    public interface IMovimientoDetalleBusiness
    {
        List<MovimientoDetalle> GetMovimientosDetalles(int IdMovimiento);

        void Create(MovimientoDetalle entity);
    }
}
