using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface ICiudadBusiness
    {
        List<Ciudad> GetCiudades(int IdDep);

        void Create(Ciudad entity);

        void Update(int IdCiudad, Ciudad entity);
    }
}