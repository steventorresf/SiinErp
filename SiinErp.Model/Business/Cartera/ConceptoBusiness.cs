using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using SiinErp.Model.Context;

namespace SiinErp.Model.Business.Cartera
{
    public class ConceptoBusiness : IConceptoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ConceptoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Concepto> GetConceptos(int IdEmpresa)
        {
            try
            {
                List<Concepto> Lista = (from c in context.Conceptos.Where(x => x.IdEmpresa == IdEmpresa)
                                        join t in context.TiposDocumentos on c.IdTipoDoc equals t.IdTipoDoc
                                        select new Concepto()
                                        {
                                            IdConcepto = c.IdConcepto,
                                            IdEmpresa = c.IdEmpresa,
                                            IdTipoDoc = c.IdTipoDoc,
                                            CodConcepto = c.CodConcepto,
                                            Descripcion = c.Descripcion,
                                            AplicaVenta = c.AplicaVenta,
                                            AplicaCartera = c.AplicaCartera,
                                            SAplicaCartera = c.AplicaCartera ? "SI" : "NO",
                                            SAplicaVenta = c.AplicaVenta ? "SI" : "NO",
                                            FechaCreacion = c.FechaCreacion,
                                            CreadoPor = c.CreadoPor,
                                            TipoDoc = t.TipoDoc
                                        }).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetConceptos", ex.Message, null);
                throw;
            }
        }

        public List<Concepto> GetConceptosByTipoDoc(int IdTipoDoc)
        {
            try
            {
                List<Concepto> Lista = context.Conceptos.Where(x => x.IdTipoDoc == IdTipoDoc).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetConceptosByTipoDoc", ex.Message, null);
                throw;
            }
        }

        public void Create(Concepto entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                context.Conceptos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateConcepto", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdConcepto, Concepto entity)
        {
            try
            {
                Concepto ob = context.Conceptos.Find(IdConcepto);
                ob.CodConcepto = entity.CodConcepto;
                ob.Descripcion = entity.Descripcion;
                ob.AplicaCartera = entity.AplicaCartera;
                ob.AplicaVenta = entity.AplicaVenta;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateConcepto", ex.Message, null);
                throw;
            }
        }
    }
}