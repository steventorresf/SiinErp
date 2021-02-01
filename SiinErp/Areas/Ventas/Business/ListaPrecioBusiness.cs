using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Abstract;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class ListaPrecioBusiness : IListaPrecioBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ListaPrecioBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<ListaPrecio> GetListaPrecios(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<ListaPrecio> Lista = context.ListaPrecios.Where(x => x.IdEmpresa == IdEmp).OrderBy(x => x.NombreLista).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetListaPrecios", ex.Message, null);
                throw;
            }
        }

        public void Create(ListaPrecio entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.ListaPrecios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateListaPrecio", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdListaPrecio, ListaPrecio entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                ListaPrecio ob = context.ListaPrecios.Find(IdListaPrecio);
                ob.NombreLista = entity.NombreLista;
                ob.Estado = entity.Estado;
                ob.ModificadoPor = entity.ModificadoPor;
                ob.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateListaPrecio", ex.Message, null);
                throw;
            }
        }
    }
}
