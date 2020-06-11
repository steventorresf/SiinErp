using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class TablasBusiness
    {
        public void Create(Tablas entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
                List<Tablas> Lista = (from ta in context.Tablas
                                      join mo in context.Modulos on ta.CodModulo equals mo.CodModulo
                                      select new Tablas()
                                      {
                                          IdTabla = ta.IdTabla,
                                          CodModulo = ta.CodModulo,
                                          CodTabla = ta.CodTabla,
                                          Descripcion = ta.Descripcion,
                                          FechaCreacion = ta.FechaCreacion,
                                          IdUsuario = ta.IdUsuario,
                                          NombreModulo = mo.Descripcion,
                                      }).OrderBy(x => x.Descripcion).OrderBy(x => x.CodModulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablas", ex.Message, null);
                throw;
            }
        }

    }
}
