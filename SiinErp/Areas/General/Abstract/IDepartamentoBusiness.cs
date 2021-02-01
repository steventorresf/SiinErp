using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IDepartamentoBusiness
    {
        List<Departamento> GetDepartamentos();

        void Create(Departamento entity);

        void Update(int IdDepartamento, Departamento entity);
    }
}
