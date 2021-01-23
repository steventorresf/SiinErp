using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class ListaPreciosDetalleBusiness
    {
        public List<ListaPreciosDetalle> GetListaPreciosDetalle(int IdListaPrecio)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<ListaPreciosDetalle> Lista = (from ld in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                                   join ar in context.Articulos on ld.IdArticulo equals ar.IdArticulo
                                                   select new ListaPreciosDetalle()
                                                   {
                                                       IdDetalleListaPrecio = ld.IdDetalleListaPrecio,
                                                       IdListaPrecio = ld.IdListaPrecio,
                                                       IdArticulo = ld.IdArticulo,
                                                       VrUnitario = ld.VrUnitario,
                                                       PcDscto = ld.PcDscto,
                                                       Articulo = ar,
                                                   }).OrderBy(x => x.IdArticulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetListaPreciosDetalle", ex.Message, null);
                throw;
            }
        }

        public List<ListaPreciosDetalle> GetListaPreciosDetalleByPrefix(JObject data)
        {
            try
            {
                int IdListaPrecio = data["idListaPrecio"].ToObject<int>();
                string Prefix = data["prefix"].ToObject<string>();

                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                SiinErpContext context = new SiinErpContext();
                List<ListaPreciosDetalle> Lista = (from ld in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                                   join ar in context.Articulos on ld.IdArticulo equals ar.IdArticulo
                                                   where ar.NombreBusqueda.Contains(ListPrefix[0])
                                                   select new ListaPreciosDetalle()
                                                   {
                                                       IdDetalleListaPrecio = ld.IdDetalleListaPrecio,
                                                       IdListaPrecio = ld.IdListaPrecio,
                                                       IdArticulo = ld.IdArticulo,
                                                       VrUnitario = ld.VrUnitario,
                                                       PcDscto = ld.PcDscto,
                                                       Articulo = ar,
                                                   }).OrderBy(x => x.IdArticulo).ToList();
                for (int i = 1; i < ListPrefix.Length; i++)
                {
                    Lista = Lista.Where(x => x.Articulo.NombreBusqueda.Contains(ListPrefix[i])).ToList();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetListaPreciosDetalle", ex.Message, null);
                throw;
            }
        }

        public void Create(ListaPreciosDetalle entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.ListaPreciosDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdListaPrecioDetalle, ListaPreciosDetalle entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                ListaPreciosDetalle ob = context.ListaPreciosDetalles.Find(IdListaPrecioDetalle);
                ob.IdArticulo = entity.IdArticulo;
                ob.VrUnitario = entity.VrUnitario;
                ob.PcDscto = entity.PcDscto;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdListaPrecioDetalle)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                ListaPreciosDetalle entity = context.ListaPreciosDetalles.Find(IdListaPrecioDetalle);
                context.ListaPreciosDetalles.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("DeleteListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }
    }
}
