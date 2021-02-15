using SiinErp.Model.Entities.Ventas;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Ventas
{
    public interface IListaPrecioBusiness
    {
        List<ListaPrecio> GetListaPrecios(int IdEmp);

        void Create(ListaPrecio entity);

        void Update(int IdListaPrecio, ListaPrecio entity);
    }
}