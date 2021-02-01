using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Abstract
{
    public interface IComprobanteDetalleBusiness
    {
        List<ComprobanteDetalle> GetAll(int IdComprobante);
    }
}
