using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ICiudadBusiness
    {
        List<Ciudad> GetCiudades(int IdDep);

        void Create(Ciudad entity);

        void Update(int IdCiudad, Ciudad entity);
    }
}
