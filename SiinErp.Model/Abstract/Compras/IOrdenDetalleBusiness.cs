using SiinErp.Model.Entities.Compras;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Compras
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