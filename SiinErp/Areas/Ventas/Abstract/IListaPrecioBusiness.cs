using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Abstract
{
    public interface IListaPrecioBusiness
    {
        List<ListaPrecio> GetListaPrecios(int IdEmp);

        void Create(ListaPrecio entity);

        void Update(int IdListaPrecio, ListaPrecio entity);
    }
}
