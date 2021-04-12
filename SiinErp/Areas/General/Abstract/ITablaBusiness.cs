using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ITablaBusiness
    {
        void Create(Tabla entity);

        void Update(int IdTabla, Tabla entity);

        List<Tabla> GetTablasVisible();
    }
}
