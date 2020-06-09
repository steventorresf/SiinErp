using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class TablasDetalleBusiness
    {
        public void Create(TablasDetalle entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                BaseContext context = new BaseContext();
                context.TablasDetalles.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdDetalle, TablasDetalle entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                TablasDetalle ob = context.TablasDetalles.Find(IdDetalle);
                ob.CodValor = entity.CodValor;
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
                BaseContext context = new BaseContext();
                TablasDetalle entity = context.TablasDetalles.Find(IdDetalle);
                entity.Orden = Orden;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateOrdenTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public List<TablasDetalle> GetAllTablaDetalleByIdTab(int IdTabla)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<TablasDetalle> Lista = context.TablasDetalles.Where(x => x.IdTabla == IdTabla).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablaDetalle", ex.Message, null);
                throw;
            }
        }

        public List<TablasDetalle> GetTablaDetalleByCod(string CodTabla)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<TablasDetalle> Lista = (from ta in context.Tablas.Where(x => x.CodTabla.Equals(CodTabla))
                                             join td in context.TablasDetalles on ta.IdTabla equals td.IdTabla
                                             where td.Estado.Equals(Constantes.EstadoActivo)
                                             select td).OrderBy(x => x.Descripcion).OrderBy(x => x.Orden).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablaDetalleActivos", ex.Message, null);
                throw;
            }
        }

    }
}
