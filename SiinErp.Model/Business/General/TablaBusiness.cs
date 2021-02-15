using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class TablaBusiness : ITablaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public TablaBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public void Create(Tabla entity)
        {
            try
            {
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