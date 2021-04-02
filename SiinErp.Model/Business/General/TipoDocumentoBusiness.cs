using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class TipoDocumentoBusiness : ITipoDocumentoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public TipoDocumentoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public TipoDocumento GetTipoDocumento(int IdEmpresa, string TipoDoc)
        {
            try
            {
                TipoDocumento tipoDocumento = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(TipoDoc) && x.IdEmpresa == IdEmpresa);
                return tipoDocumento;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTipoDocumentoGen", ex.Message, null);
                throw;
            }
        }

        public List<TipoDocumento> GetTiposDocumentos(int IdEmpresa)
        {
            try
            {
                List<TipoDocumento> Lista = (from td in context.TiposDocumentos.Where(x => x.IdEmpresa == IdEmpresa)
                                             join mo in context.Modulos on td.CodModulo equals mo.CodModulo
                                             join cd in context.TablasDetalles on td.IdDetClaseDoc equals cd.IdDetalle
                                             select new TipoDocumento()
                                             {
                                                 IdTipoDoc = td.IdTipoDoc,
                                                 IdEmpresa = td.IdEmpresa,
                                                 CodModulo = td.CodModulo,
                                                 TipoDoc = td.TipoDoc,
                                                 NumDoc = td.NumDoc,
                                                 Descripcion = td.Descripcion,
                                                 IdDetTransaccion = td.IdDetTransaccion,
                                                 IdDetClaseDoc = td.IdDetClaseDoc,
                                                 IdCuentaCargo = td.IdCuentaCargo,
                                                 IdCuentaDoc = td.IdCuentaDoc,
                                                 IdCuentaOtro = td.IdCuentaOtro,
                                                 IdCuentaReteFuente = td.IdCuentaReteFuente,
                                                 FechaCreacion = td.FechaCreacion,
                                                 CreadoPor = td.CreadoPor,
                                                 NomTransaccion = td.IdDetTransaccion > 0 ? "Suma" : td.IdDetTransaccion < 0 ? "Resta" : "*No Aplica*",
                                                 NombreModulo = mo.Descripcion,
                                                 NomClaseDoc = cd.Descripcion,
                                             }).OrderBy(x => x.Descripcion).OrderBy(x => x.TipoDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTiposDocumentosGen", ex.Message, null);
                throw;
            }
        }

        public List<TipoDocumento> GetTiposDocumentosByModulo(int IdEmpresa, string CodModulo)
        {
            try
            {
                List<TipoDocumento> Lista = context.TiposDocumentos.Where(x => x.IdEmpresa == IdEmpresa && x.CodModulo.Equals(CodModulo)).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTiposDocumentosByModulo", ex.Message, null);
                throw;
            }
        }

        public void Create(TipoDocumento entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                context.TiposDocumentos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateTiposDocumentoGen", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, TipoDocumento entity)
        {
            try
            {
                TipoDocumento ob = context.TiposDocumentos.Find(IdTipoDoc);
                ob.CodModulo = entity.CodModulo;
                ob.TipoDoc = entity.TipoDoc;
                ob.NumDoc = entity.NumDoc;
                ob.Descripcion = entity.Descripcion;
                ob.IdDetTransaccion = entity.IdDetTransaccion;
                ob.IdDetClaseDoc = entity.IdDetClaseDoc;
                ob.IdCuentaDoc = entity.IdCuentaDoc;
                ob.IdCuentaCargo = entity.IdCuentaCargo;
                ob.IdCuentaOtro = entity.IdCuentaOtro;
                ob.IdCuentaReteFuente = entity.IdCuentaReteFuente;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateTipoDocumentoGen", ex.Message, null);
                throw;
            }
        }
    }
}