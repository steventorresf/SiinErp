using SiinErp.Areas.Tesoreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Tesoreria.Abstract
{
    public interface IPagoBusiness
    {
        List<Pago> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin);

        void Create(Pago entity, List<PagoDetalle> listDetalleFac);
    }
}
