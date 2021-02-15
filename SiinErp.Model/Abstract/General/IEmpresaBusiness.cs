using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IEmpresaBusiness
    {
        List<Empresa> GetEmpresas();

        List<Empresa> GetEmpresasAct();

        void Create(Empresa entity);

        void Update(int IdEmpresa, Empresa entity);
    }
}