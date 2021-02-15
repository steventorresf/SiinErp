using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IParametroBusiness
    {
        List<Parametro> GetParametros();

        void Create(Parametro entity);

        void Update(int IdParametro, Parametro entity);
    }
}