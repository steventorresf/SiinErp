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
        public List<TiposDocumento> GetTiposDocumentos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TiposDocumento> Lista = (from td in context.TiposDocumentos.Where(x => x.IdEmpresa == IdEmpresa)
                                              join tr in context.TablasDetalles on td.IdDetTransaccion equals tr.IdDetalle
                                              join cd in context.TablasDetalles on td.IdDetClaseDoc equals cd.IdDetalle
                                              select new TiposDocumento()
                                              {
                                                  IdTipoDoc = td.IdTipoDoc,
                                                  IdEmpresa = td.IdEmpresa,
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
                                                  NomTransaccion = tr.Descripcion,
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
