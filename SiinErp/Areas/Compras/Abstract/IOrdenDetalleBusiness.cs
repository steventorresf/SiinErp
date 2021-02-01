using SiinErp.Areas.Compras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Abstract
{
    public interface IOrdenDetalleBusiness
    {
        void Create(OrdenDetalle entity);

        List<OrdenDetalle> GetOrdenDetalle(int IdOrden);

        void UpdateOrdenDetalle(int IdOrdenDetalle, OrdenDetalle entity);

        void DeleteOrdenDetalle(int IdOrdenDetalle);

        void UpdateVrNetoOrden(int IdOrden);
    }
}
