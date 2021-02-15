using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Ventas
{
    public class ListaPrecioDetalleBusiness : IListaPrecioDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ListaPrecioDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<ListaPrecioDetalle> GetListaPreciosDetalle(int IdListaPrecio)
        {
            try
            {
                List<ListaPrecioDetalle> Lista = (from ld in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                                  join ar in context.Articulos on ld.IdArticulo equals ar.IdArticulo
                                                  select new ListaPrecioDetalle()
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
                errorBusiness.Create("GetListaPreciosDetalle", ex.Message, null);
                throw;
            }
        }

        public List<ListaPrecioDetalle> GetListaPreciosDetalleByPrefix(JObject data)
        {
            try
            {
                int IdListaPrecio = data["idListaPrecio"].ToObject<int>();
                string Prefix = data["prefix"].ToObject<string>();
                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<ListaPrecioDetalle> Lista = (from ld in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                                  join ar in context.Articulos on ld.IdArticulo equals ar.IdArticulo
                                                  where ar.NombreBusqueda.Contains(ListPrefix[0])
                                                  select new ListaPrecioDetalle()
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
                errorBusiness.Create("GetListaPreciosDetalle", ex.Message, null);
                throw;
            }
        }

        public void Create(ListaPrecioDetalle entity)
        {
            try
            {
                context.ListaPreciosDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdListaPrecioDetalle, ListaPrecioDetalle entity)
        {
            try
            {
                ListaPrecioDetalle ob = context.ListaPreciosDetalles.Find(IdListaPrecioDetalle);
                ob.IdArticulo = entity.IdArticulo;
                ob.VrUnitario = entity.VrUnitario;
                ob.PcDscto = entity.PcDscto;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdListaPrecioDetalle)
        {
            try
            {
                ListaPrecioDetalle entity = context.ListaPreciosDetalles.Find(IdListaPrecioDetalle);
                context.ListaPreciosDetalles.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteListaPrecioDetalle", ex.Message, null);
                throw;
            }
        }
    }
}