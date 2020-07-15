using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TablasBusiness
    {
        public void Create(Tablas entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Tablas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTabla", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTabla, Tablas entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Tablas ob = context.Tablas.Find(IdTabla);
                ob.CodTabla = entity.CodTabla;
                ob.Descripcion = entity.Descripcion;
                ob.CodModulo = entity.CodModulo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTabla", ex.Message, null);
                throw;
            }
        }

        public List<Tablas> GetTablas()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tablas> Lista = (from ta in context.Tablas
                                      join mo in context.Modulos on ta.CodModulo equals mo.CodModulo
                                      select new Tablas()
                                      {
                                          IdTabla = ta.IdTabla,
                                          CodModulo = ta.CodModulo,
                                          CodTabla = ta.CodTabla,
                                          Descripcion = ta.Descripcion,
                                      }).OrderBy(x => x.Descripcion).OrderBy(x => x.CodModulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablas", ex.Message, null);
                throw;
            }
        }

        public List<Tablas> GetNoTablasEmpresa(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tablas> Lista = (from ta in context.Tablas
                                      join te in context.TablasEmpresas.Where(x => x.IdEmpresa == IdEmpresa) on ta.IdTabla equals te.IdTabla into joined
                                      from j in joined.DefaultIfEmpty()
                                      where j == null
                                      select new Tablas()
                                      {
                                          IdTabla = ta.IdTabla,
                                          CodTabla = ta.CodTabla,
                                          Descripcion = ta.Descripcion,
                                          CodModulo = ta.CodModulo
                                      }).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNoTablasEmpresa", ex.Message, null);
                throw;
            }
        }

    }
}
