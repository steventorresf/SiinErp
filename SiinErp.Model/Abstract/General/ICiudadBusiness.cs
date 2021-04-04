using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface ICiudadBusiness
    {
        void Create(Ciudad entity);
        List<Ciudad> GetAll();
        List<Ciudad> GetByIdDepartamento(int IdDepartamento);
        void Update(int IdCiudad, Ciudad entity);
        void Delete(int id);
    }
}