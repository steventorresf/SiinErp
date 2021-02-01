using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IModuloBusiness
    {
        List<Modulo> GetModulos();

        List<Modulo> GetModulosPer();
    }
}
