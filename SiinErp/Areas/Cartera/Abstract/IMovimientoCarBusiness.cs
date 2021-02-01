using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Abstract
{
    public interface IMovimientoCarBusiness
    {
        void Create(MovimientoCar entity, List<Movimiento> listDetalleFac);

        List<MovimientoCar> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin);

        void Anular(int IdMov, string NomUsu);
    }
}
