using SiinErp.Models;
using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.Contabilidad.Abstract;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class TipoContabBusiness : ITipoContabBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public TipoContabBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<TipoContab> GetTiposContab(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TipoContab> Lista = context.TiposContab.OrderBy(x => x.TipoDoc).ToList();
             
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTiposContab", ex.Message, null);
                throw;
            }
        }

        
        public TipoContab GetTipoContab(int IdEmpresa, string TipoDoc)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TipoContab entity = context.TiposContab.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.TipoDoc.Equals(TipoDoc));
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTipoContab", ex.Message, null);
                throw;
            }
        }

        public void Create(TipoContab entity)
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
                errorBusiness.Create("CreateTiposContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, TipoContab entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TipoContab ob = context.TiposContab.Find(IdTipoDoc);
                ob.TipoDoc = entity.TipoDoc;
                ob.NumDoc = entity.NumDoc;
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTiposContab", ex.Message, null);
                throw;
            }
        }


    }
}