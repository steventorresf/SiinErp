using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IPaisBusiness
    {
        List<Pais> GetPaises();

        void Create(Pais entity);

        void Update(int IdPais, Pais entity);
    }
}