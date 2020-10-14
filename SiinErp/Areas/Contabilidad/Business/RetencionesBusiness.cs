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
    public class RetencionesBusiness
    {
        public List<Retenciones> GetRetenciones(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Retenciones> Lista = context.Retenciones.OrderBy(x => x.CodRetencion).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetRetsContab", ex.Message, null);
                throw;
            }
        }


        public Retenciones GetTipoRet(int IdEmpresa, string TipoDoc)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Retenciones entity = context.Retenciones.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.CodRetencion.Equals(TipoDoc));
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetRetContab", ex.Message, null);
                throw;
            }
        }

        public void Create(Retenciones entity)
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
                ErroresBusiness.Create("CreateRetContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, Retenciones entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Retenciones ob = context.Retenciones.Find(IdTipoDoc);
                ob.CodRetencion = entity.CodRetencion;
                ob.Porcentaje = entity.Porcentaje;
                ob.BaseRetencion = entity.BaseRetencion;
                ob.Descripcion = entity.Descripcion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateRetContab", ex.Message, null);
                throw;
            }
        }


    }
}