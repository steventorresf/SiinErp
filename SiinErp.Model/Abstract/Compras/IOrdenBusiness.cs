using SiinErp.Model.Entities.Compras;
using System;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Compras
{
    public interface IOrdenBusiness
    {
        List<Orden> GetOrdenes(int IdEmp, DateTime FechaIni, DateTime FechaFin);

        List<Orden> GetOrdenesPendientes(int IdEmp);

        void Create(Orden entity);

        void Update(int IdOrd, Orden entity);
    }
}