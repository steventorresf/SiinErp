using SiinErp.Model.Entities.Ventas;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Ventas
{
    public interface ICajaDetalleBusiness
    {
        List<CajaDetalle> GetCajaDetalleById(int IdCaja);

        void Create(CajaDetalle entity);

        int GetCantidadDetalleCaja(int IdCaja);
    }
}