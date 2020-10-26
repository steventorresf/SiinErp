using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class ComprobantesBusiness
    {
        public void Create(JObject data)
        {
            try
            {
                Comprobantes entity = data["entity"].ToObject<Comprobantes>();
                List<ComprobantesDetalle> listEntity = data["listEntity"].ToObject<List<ComprobantesDetalle>>();

                SiinErpContext context = new SiinErpContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    TiposContab entityTipoDoc = context.TiposContab.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                    entityTipoDoc.NumDoc++;
                    context.SaveChanges();

                    entity.NumDoc = entityTipoDoc.NumDoc;
                    entity.FechaDoc = entity.FechaDoc.ToOffset(new TimeSpan(-5, 0, 0));
                    entity.FechaCreacion = DateTimeOffset.Now;
                    context.Comprobantes.Add(entity);
                    context.SaveChanges();

                    Comprobantes obEntity = context.Comprobantes.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                    foreach(ComprobantesDetalle d in listEntity)
                    {
                        d.IdComprobante = obEntity.IdComprobante;
                    }

                    context.ComprobantesDetalles.AddRange(listEntity);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateComprobantesContab", ex.Message, null);
                throw;
            }
        }
    }
}
