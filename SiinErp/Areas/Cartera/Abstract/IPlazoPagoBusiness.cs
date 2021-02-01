using SiinErp.Areas.Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Abstract
{
    public interface IPlazoPagoBusiness
    {
        List<PlazoPago> GetPlazosPagos(int IdEmpresa);

        void Create(PlazoPago entity);

        void Update(int IdPlazoPago, PlazoPago entity);
    }
}
