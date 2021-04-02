using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Abstract.Inventario
{
    public interface IMovimientoFormaPagoBusiness
    {
        List<MovimientoFormaPago> GetMovimientoFormasPago(int IdMovimiento);
    }
}
