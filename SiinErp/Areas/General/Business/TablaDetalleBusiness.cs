using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class TablaDetalleBusiness : ITablaDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public TablaDetalleBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public void Create(TablaDetalle entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
                TablaDetalle ob = context.TablasDetalles.Find(IdDetalle);
                ob.Codigo = entity.Codigo;
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                ob.ModificadoPor = entity.ModificadoPor;
                ob.FechaModificado = DateTimeOffset.Now;
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
                List<TablaDetalle> Lista = (from ta in context.Tablas.Where(x => x.CodTabla.Equals(CodTabla))
                                            join td in context.TablasDetalles on ta.IdTabla equals td.IdTabla
                                            where td.IdEmpresa == IdEmpresa && td.Estado.Equals(Constantes.EstadoActivo)
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
