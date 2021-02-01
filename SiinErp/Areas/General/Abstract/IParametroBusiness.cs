using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IParametroBusiness
    {
        List<Parametro> GetParametros();

        void Create(Parametro entity);

        void Update(int IdParametro, Parametro entity);
    }
}
