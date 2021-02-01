using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IPaisBusiness
    {
        List<Pais> GetPaises();

        void Create(Pais entity);

        void Update(int IdPais, Pais entity);
    }
}
