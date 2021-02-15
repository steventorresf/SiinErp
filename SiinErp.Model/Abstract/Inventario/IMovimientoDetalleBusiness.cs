using SiinErp.Model.Entities.Inventario;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Inventario
{
    public interface IMovimientoDetalleBusiness
    {
        List<MovimientoDetalle> GetMovimientosDetalles(int IdMovimiento);

        void Create(MovimientoDetalle entity);
    }
}