using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface IModuloBusiness
    {
        List<Modulo> GetModulos();

        List<Modulo> GetModulosPer();
    }
}