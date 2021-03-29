﻿using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.Inventario;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Inventario
{
    public interface IArticuloBusiness
    {
        List<Articulo> GetArticulos(int IdEmp);

        List<Articulo> GetArticulosByIdListaPrecio(int IdListaPrecio);

        Articulo GetByCodigoListaP(JObject data);

        List<Articulo> GetByPrefixListaP(JObject data);

        List<Articulo> GetArticulosByAlmacenPrefix(int IdDetAlm, int IdEmp, string Prefix);

        void Create(Articulo entity);

        void Update(int IdArticulo, Articulo entity);
    }
}