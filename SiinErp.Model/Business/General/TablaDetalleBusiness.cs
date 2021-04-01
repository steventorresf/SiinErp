using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class TablaDetalleBusiness : ITablaDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public TablaDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public void Create(TablaDetalle entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                context.TablasDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateTablaEmpresaDetalle", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdDetalle, TablaDetalle entity)
        {
            try
            {
                TablaDetalle ob = context.TablasDetalles.Find(IdDetalle);
                ob.Descripcion = entity.Descripcion;
                ob.EstadoFila = entity.EstadoFila;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public void UpdateOrden(int IdDetalle, short Orden)
        {
            try
            {
                TablaDetalle entity = context.TablasDetalles.Find(IdDetalle);
                entity.Orden = Orden;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateOrdenTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public List<TablaDetalle> GetAllTablaDetalleByIdTabEmp(int IdTabla, int IdEmpresa)
        {
            try
            {
                List<TablaDetalle> Lista = context.TablasDetalles.Where(x => x.IdTabla == IdTabla && x.IdEmpresa == IdEmpresa).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllTablaDetalleByIdTabEmp", ex.Message, null);
                throw;
            }
        }

        public List<TablaDetalle> GetTablaEmpresaDetalleByCod(string CodTabla, int IdEmpresa)
        {
            try
            {
                List<TablaDetalle> Lista = (from ta in context.Tablas.Where(x => x.CodTabla.Equals(CodTabla))
                                            join td in context.TablasDetalles on ta.IdTabla equals td.IdTabla
                                            where td.IdEmpresa == IdEmpresa && td.EstadoFila.Equals(Constantes.EstadoActivo)
                                            select td).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTablaEmpresaDetalleByCod", ex.Message, null);
                throw;
            }
        }
    }
}