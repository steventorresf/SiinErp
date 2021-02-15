using SiinErp.Model.Entities.Tesoreria;
using System;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Tesoreria
{
    public interface IPagoBusiness
    {
        List<Pago> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin);

        void Create(Pago entity, List<PagoDetalle> listDetalleFac);
    }
}