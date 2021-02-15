using SiinErp.Model.Entities.Contabilidad;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Contabilidad
{
    public interface IComprobanteDetalleBusiness
    {
        List<ComprobanteDetalle> GetAll(int IdComprobante);
    }
}