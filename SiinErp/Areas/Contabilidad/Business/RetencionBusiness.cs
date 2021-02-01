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
    public class RetencionBusiness : IRetencionBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public RetencionBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Retencion> GetRetenciones(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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