using SiinErp.Model.Entities.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Abstract.Reportes
{
    public interface IReporteBusiness
    {
        List<NumeroFactura> GetNumeroFactura(int IdFactura);
    }
}
