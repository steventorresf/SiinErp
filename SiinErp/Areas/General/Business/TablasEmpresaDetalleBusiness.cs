using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TablasEmpresaDetalleBusiness
    {
        public void Create(TablasEmpresaDetalle entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.TablasEmpresaDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTablaEmpresaDetalle", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdDetalle, TablasEmpresaDetalle entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TablasEmpresaDetalle ob = context.TablasEmpresaDetalles.Find(IdDetalle);
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public void UpdateOrden(int IdDetalle, short Orden)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TablasEmpresaDetalle entity = context.TablasEmpresaDetalles.Find(IdDetalle);
                entity.Orden = Orden;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateOrdenTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public List<TablasEmpresaDetalle> GetAllTablaDetalleByIdTabEmp(int IdTablaEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TablasEmpresaDetalle> Lista = context.TablasEmpresaDetalles.Where(x => x.IdTablaEmpresa == IdTablaEmpresa).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllTablaDetalleByIdTabEmp", ex.Message, null);
                throw;
            }
        }

        public List<TablasEmpresaDetalle> GetTablaEmpresaDetalleByCod(string CodTabla, int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TablasEmpresaDetalle> Lista = (from ta in context.Tablas.Where(x => x.CodTabla.Equals(CodTabla))
                                                    join te in context.TablasEmpresas.Where(x => x.IdEmpresa == IdEmpresa) on ta.IdTabla equals te.IdTabla
                                                    join td in context.TablasEmpresaDetalles on te.IdTablaEmpresa equals td.IdTablaEmpresa
                                                    where td.Estado.Equals(Constantes.EstadoActivo)
                                                    select td).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablaEmpresaDetalleByCod", ex.Message, null);
                throw;
            }
        }

    }
}
