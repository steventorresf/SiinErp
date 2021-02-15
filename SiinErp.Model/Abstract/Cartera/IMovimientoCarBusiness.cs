using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Cartera
{
    public interface IMovimientoCarBusiness
    {
        void Create(MovimientoCar entity, List<Movimiento> listDetalleFac);

        List<MovimientoCar> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin);

        void Anular(int IdMov, string NomUsu);
    }
}