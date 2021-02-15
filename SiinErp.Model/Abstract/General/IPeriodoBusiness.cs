using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IPeriodoBusiness
    {
        void Create(Periodo entity);

        void Update(int IdPeriodo, Periodo entity);

        List<Periodo> GetPeriodos(int IdEmpresa);

        string[] GetSiguientePeriodo(int IdEmpresa, string CodModulo);
    }
}