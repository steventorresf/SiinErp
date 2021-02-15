using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Contabilidad
{
    public class RetencionBusiness : IRetencionBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public RetencionBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Retencion> GetRetenciones(int IdEmpresa)
        {
            try
            {
                List<Retencion> Lista = context.Retenciones.OrderBy(x => x.CodRetencion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetRetsContab", ex.Message, null);
                throw;
            }
        }


        public Retencion GetTipoRet(int IdEmpresa, string TipoDoc)
        {
            try
            {
                Retencion entity = context.Retenciones.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.CodRetencion.Equals(TipoDoc));
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetRetContab", ex.Message, null);
                throw;
            }
        }

        public void Create(Retencion entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                context.Retenciones.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateRetContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, Retencion entity)
        {
            try
            {
                Retencion ob = context.Retenciones.Find(IdTipoDoc);
                ob.CodRetencion = entity.CodRetencion;
                ob.Porcentaje = entity.Porcentaje;
                ob.BaseRetencion = entity.BaseRetencion;
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateRetContab", ex.Message, null);
                throw;
            }
        }
    }
}