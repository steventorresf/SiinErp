using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.Ventas;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Ventas
{
    public interface IListaPrecioDetalleBusiness
    {
        List<ListaPrecioDetalle> GetListaPreciosDetalle(int IdListaPrecio);
        List<ListaPrecioDetalle> GetListaPreciosDetalleByPrefix(JObject data);
        void Create(ListaPrecioDetalle entity);
        void Creates(List<ListaPrecioDetalle> Listado);
        void Update(int IdListaPrecioDetalle, ListaPrecioDetalle entity);
        void Delete(int IdListaPrecioDetalle);
    }
}