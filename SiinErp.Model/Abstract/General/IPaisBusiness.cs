using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IPaisBusiness
    {
        void Create(int id, Pais entity);
        Pais Read(int id);
        List<Pais> ReadAll();
        void Update(int id, Pais entity);
        void Delete(int id);
    }
}