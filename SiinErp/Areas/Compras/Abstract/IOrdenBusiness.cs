using SiinErp.Areas.Compras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Abstract
{
    public interface IOrdenBusiness
    {
        List<Orden> GetOrdenes(int IdEmp, DateTime FechaIni, DateTime FechaFin);

        List<Orden> GetOrdenesPendientes(int IdEmp);

        void Create(Orden entity);

        void Update(int IdOrd, Orden entity);
    }
}
