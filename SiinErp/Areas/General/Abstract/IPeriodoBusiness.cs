using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IPeriodoBusiness
    {
        void Create(Periodo entity);

        void Update(int IdPeriodo, Periodo entity);

        List<Periodo> GetPeriodos(int IdEmpresa);

        string[] GetSiguientePeriodo(int IdEmpresa, string CodModulo);
    }
}
