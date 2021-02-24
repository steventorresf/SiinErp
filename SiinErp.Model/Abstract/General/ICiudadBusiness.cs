using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface ICiudadBusiness
    {
        void Create(int id, Ciudad entity);
        Ciudad Read(int id);
        List<Ciudad> ReadAll();
        List<Ciudad> ReadAll(int id);
        void Update(int id, Ciudad entity);
        void Delete(int id);
    }
}