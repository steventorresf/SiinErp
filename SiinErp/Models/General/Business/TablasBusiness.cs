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
        public void Update(string CodTabla, Tablas entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Tablas ob = context.Tablas.Find(CodTabla);
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
                List<Tablas> Lista = context.Tablas.OrderBy(x => x.Descripcion).OrderBy(x => x.CodModulo).ToList();
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
