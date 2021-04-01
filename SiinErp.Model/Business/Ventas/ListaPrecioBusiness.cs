using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Ventas
{
    public class ListaPrecioBusiness : IListaPrecioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ListaPrecioBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<ListaPrecio> GetListaPrecios(int IdEmp)
        {
            try
            {
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
                ListaPrecio ob = context.ListaPrecios.Find(IdListaPrecio);
                ob.NombreLista = entity.NombreLista;
                ob.EstadoFila = entity.EstadoFila;
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