using SiinErp.Models;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Business
{
    public class TiposDocBusiness
    {
        public List<TiposDoc> GetTiposDoc(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<TiposDoc> Lista = (from td in context.TiposDoc.Where(x => x.IdEmpresa == IdEmpresa)
                                              join tr in context.TablasDetalles on td.IdDetTransaccion equals tr.IdDetalle
                                              join ti in context.TablasDetalles on td.IdDetAlmacen equals ti.IdDetalle
                                        select new TiposDoc()
                                              {
                                                  IdTipoDoc = td.IdTipoDoc,
                                                  IdEmpresa = td.IdEmpresa,
                                                  TipoDoc = td.TipoDoc,
                                                  NumDoc = td.NumDoc,
                                                  Descripcion = td.Descripcion,
                                                  IdDetTransaccion = td.IdDetTransaccion,
                                                  IdDetAlmacen = td.IdDetAlmacen,
                                                  FechaCreacion = td.FechaCreacion,
                                                  IdUsuario = td.IdUsuario,
                                                  NomTransaccion = tr.Descripcion,
                                                  NomAlmacen = ti.Descripcion
                                              }).OrderBy(x => x.Descripcion).OrderBy(x => x.TipoDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTiposDocInv", ex.Message, null);
                throw;
            }
        }

        public void Create(TiposDoc entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.TiposDoc.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTiposDocInv", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTipoDoc, TiposDoc entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                TiposDoc ob = context.TiposDoc.Find(IdTipoDoc);
                ob.TipoDoc = entity.TipoDoc;
                ob.NumDoc = entity.NumDoc;
                ob.Descripcion = entity.Descripcion;
                ob.IdDetTransaccion = entity.IdDetTransaccion;
                ob.IdDetAlmacen = entity.IdDetAlmacen;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateTiposDocInv", ex.Message, null);
                throw;
            }
        }


    }
}