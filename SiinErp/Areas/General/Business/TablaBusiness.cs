using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class TablaBusiness : ITablaBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public TablaBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public void Create(Tabla entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Tablas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateTabla", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTabla, Tabla entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Tabla ob = context.Tablas.Find(IdTabla);
                ob.CodTabla = entity.CodTabla;
                ob.Descripcion = entity.Descripcion;
                ob.CodModulo = entity.CodModulo;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTabla", ex.Message, null);
                throw;
            }
        }

        public List<Tabla> GetTablas()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tabla> Lista = (from ta in context.Tablas
                                      join mo in context.Modulos on ta.CodModulo equals mo.CodModulo
                                      select new Tabla()
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
                errorBusiness.Create("GetTablas", ex.Message, null);
                throw;
            }
        }

    }
}
