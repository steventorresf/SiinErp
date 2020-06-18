using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class ListaPreciosBusiness
    {
        public List<ListaPrecios> GetListaPrecios(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<ListaPrecios> Lista = context.ListaPrecios.Where(x => x.IdEmpresa == IdEmp).OrderBy(x => x.NombreLista).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetListaPrecios", ex.Message, null);
                throw;
            }
        }

        public void Create(ListaPrecios entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.ListaPrecios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateListaPrecio", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdListaPrecio, ListaPrecios entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                ListaPrecios ob = context.ListaPrecios.Find(IdListaPrecio);
                ob.NombreLista = entity.NombreLista;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateListaPrecio", ex.Message, null);
                throw;
            }
        }
    }
}
