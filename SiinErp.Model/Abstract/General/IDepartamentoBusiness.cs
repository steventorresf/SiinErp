using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IDepartamentoBusiness
    {
        List<Departamento> GetDepartamentos();

        void Create(Departamento entity);

        void Update(int IdDepartamento, Departamento entity);
    }
}