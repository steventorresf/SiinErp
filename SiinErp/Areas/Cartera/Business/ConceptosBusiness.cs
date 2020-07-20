using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Business
{
    public class ConceptosBusiness
    {
        public List<Conceptos> GetConceptos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Conceptos> Lista = (from c in context.Conceptos.Where(x => x.IdEmpresa == IdEmpresa)
                                         select new Conceptos()
                                         {
                                             IdConcepto = c.IdConcepto,
                                             IdEmpresa = c.IdEmpresa,
                                             CodConcepto = c.CodConcepto,
                                             Descripcion = c.Descripcion,
                                             AplicaVenta = c.AplicaVenta,
                                             AplicaCartera = c.AplicaCartera,
                                             SAplicaCartera = c.AplicaCartera ? "SI" : "NO",
                                             SAplicaVenta = c.AplicaVenta ? "SI" : "NO",
                                             FechaCreacion = c.FechaCreacion,
                                             CreadoPor = c.CreadoPor,
                                         }).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetConceptos", ex.Message, null);
                throw;
            }
        }

        public void Create(Conceptos entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.Conceptos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateConcepto", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdConcepto, Conceptos entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Conceptos ob = context.Conceptos.Find(IdConcepto);
                ob.CodConcepto = entity.CodConcepto;
                ob.Descripcion = entity.Descripcion;
                ob.AplicaCartera = entity.AplicaCartera;
                ob.AplicaVenta = entity.AplicaVenta;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateConcepto", ex.Message, null);
                throw;
            }
        }
    }
}
