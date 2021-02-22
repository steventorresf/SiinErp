using Newtonsoft.Json.Linq;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Abstract
{
    public interface IArticuloBusiness
    {
        List<Articulo> GetArticulos(int IdEmp);

        List<Articulo> GetAllByPrefix(JObject data);

        List<Articulo> GetArticulosByIdListaPrecio(int IdListaPrecio);

        Articulo GetByCodigoListaP(JObject data);

        List<Articulo> GetByPrefixListaP(JObject data);

        List<Articulo> GetArticulosByAlmacenPrefix(int IdDetAlm, int IdEmp, string Prefix);

        void Create(Articulo entity);

        void Update(int IdArticulo, Articulo entity);
    }
}
