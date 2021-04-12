using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Abstract
{
    public interface IMovimientoFormaPagoBusiness
    {
        List<MovimientoFormaPago> GetMovimientoFormasPago(int IdMovimiento);
    }
}
