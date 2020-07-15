using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TablasEmpresaBusiness
    {
        public void Create(TablasEmpresa entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.TablasEmpresas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTablaEmpresa", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTablaEmpresa, TablasEmpresa entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TablasEmpresa ob = context.TablasEmpresas.Find(IdTablaEmpresa);
                ob.FechaModificado = entity.FechaModificado;
                ob.ModificadoPor = entity.ModificadoPor;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTablaEmpresa", ex.Message, null);
                throw;
            }
        }

        public List<TablasEmpresa> GetTablasEmpresa(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TablasEmpresa> Lista = (from te in context.TablasEmpresas.Where(x => x.IdEmpresa == IdEmpresa)
                                             join ta in context.Tablas on te.IdTabla equals ta.IdTabla
                                             join mo in context.Modulos on ta.CodModulo equals mo.CodModulo
                                             select new TablasEmpresa()
                                             {
                                                 IdTablaEmpresa = te.IdTablaEmpresa,
                                                 IdTabla = te.IdTabla,
                                                 Tabla = ta,
                                                 Modulo = mo,
                                                 FechaCreacion = te.FechaCreacion,
                                                 CreadoPor = te.CreadoPor,
                                             }).OrderBy(x => x.Tabla.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTablasEmpresa", ex.Message, null);
                throw;
            }
        }
    }
}
