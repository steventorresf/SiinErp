using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface ITablaBusiness
    {
        void Create(Tabla entity);

        void Update(int IdTabla, Tabla entity);

        List<Tabla> GetTablas();
    }
}