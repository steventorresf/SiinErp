using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Contabilidad
{
    public class TipoContabBusiness : ITipoContabBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public TipoContabBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<TipoContab> GetTiposContab(int IdEmpresa)
        {
            try
            {
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