using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TiposDocumentoBusiness
    {
        public TiposDocumento GetTipoDocumento(int IdEmpresa, string TipoDoc)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TiposDocumento tipoDocumento = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(TipoDoc) && x.IdEmpresa == IdEmpresa);
                return tipoDocumento;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetTipoDocumentoGen", ex.Message, null);
                throw;
            }
        }

        public List<TiposDocumento> GetTiposDocumentos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TiposDocumento> Lista = (from td in context.TiposDocumentos.Where(x => x.IdEmpresa == IdEmpresa)
                                              join mo in context.Modulos on td.CodModulo equals mo.CodModulo
                                              join cd in context.TablasDetalles on td.IdDetClaseDoc equals cd.IdDetalle
                                              select new TiposDocumento()
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
                                                  IdUsuario = td.IdUsuario,
                                                  NomTransaccion = td.IdDetTransaccion > 0 ? "Suma" : td.IdDetTransaccion < 0 ? "Resta" : "*No Aplica*",
                                                  NombreModulo = mo.Descripcion,
                                                  NomClaseDoc = cd.Descripcion,
                                              }).OrderBy(x => x.Descripcion).OrderBy(x => x.TipoDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTiposDocumentosGen", ex.Message, null);
                throw;
            }
        }

        public List<TiposDocumento> GetTiposDocumentosByModulo(int IdEmpresa, string CodModulo)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TiposDocumento> Lista = context.TiposDocumentos.Where(x => x.IdEmpresa == IdEmpresa && x.CodModulo.Equals(CodModulo)).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTiposDocumentosByModulo", ex.Message, null);
                throw;
            }
        }

        public void Create(TiposDocumento entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.TiposDocumentos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTiposDocumentoGen", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, TiposDocumento entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TiposDocumento ob = context.TiposDocumentos.Find(IdTipoDoc);
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
                ErroresBusiness.Create("UpdateTipoDocumentoGen", ex.Message, null);
                throw;
            }
        }


    }
}
