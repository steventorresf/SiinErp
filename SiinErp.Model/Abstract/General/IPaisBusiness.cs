using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IPaisBusiness
    {
        void Create(Pais entity);
        Pais Get(int id);
        List<Pais> GetAll();
        void Update(int id, Pais entity);
        void Delete(int id);
    }
}