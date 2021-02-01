using Newtonsoft.Json.Linq;
using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Abstract
{
    public interface IListaPrecioDetalleBusiness
    {
        List<ListaPrecioDetalle> GetListaPreciosDetalle(int IdListaPrecio);

        List<ListaPrecioDetalle> GetListaPreciosDetalleByPrefix(JObject data);

        void Create(ListaPrecioDetalle entity);

        void Update(int IdListaPrecioDetalle, ListaPrecioDetalle entity);

        void Delete(int IdListaPrecioDetalle);
    }
}
