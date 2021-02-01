using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IEmpresaBusiness
    {
        List<Empresa> GetEmpresas();

        List<Empresa> GetEmpresasAct();

        void Create(Empresa entity);

        void Update(int IdEmpresa, Empresa entity);
    }
}
