using SiinErp.Models;
using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class TiposContabBusiness
    {
        public List<TiposContab> GetTiposContab(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TiposContab> Lista = context.TiposContab.OrderBy(x => x.TipoDoc).ToList();
             
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTiposContab", ex.Message, null);
                throw;
            }
        }

        
        public TiposContab GetTipoContab(int IdEmpresa, string TipoDoc)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TiposContab entity = context.TiposContab.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.TipoDoc.Equals(TipoDoc));
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTipoContab", ex.Message, null);
                throw;
            }
        }

        public void Create(TiposContab entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.TiposContab.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTiposContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, TiposContab entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TiposContab ob = context.TiposContab.Find(IdTipoDoc);
                ob.TipoDoc = entity.TipoDoc;
                ob.NumDoc = entity.NumDoc;
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTiposContab", ex.Message, null);
                throw;
            }
        }


    }
}