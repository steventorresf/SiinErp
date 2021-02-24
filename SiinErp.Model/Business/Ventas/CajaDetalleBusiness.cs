using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Ventas
{
    public class CajaDetalleBusiness : ICajaDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public CajaDetalleBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<CajaDetalle> GetCajaDetalleById(int IdCaja)
        {
            try
            {
                List<CajaDetalle> Lista = (from ca in context.CajaDetalle.Where(x => x.IdCaja == IdCaja && x.Estado.Equals(Constantes.EstadoActivo))
                                           select new CajaDetalle()
                                           {
                                               IdCajaDetalle = ca.IdCajaDetalle,
                                               IdCaja = ca.IdCaja,
                                               IdDetFormaPago = ca.IdDetFormaPago,
                                               Transaccion = ca.Transaccion,
                                               Valor = ca.Valor,
                                               Comentario = ca.Comentario,
                                               Estado = ca.Estado,
                                               FechaCreacion = ca.FechaCreacion,
                                               CreadoPor = ca.CreadoPor,
                                               FechaModificado = ca.FechaModificado,
                                               ModificadoPor = ca.ModificadoPor,
                                           }).OrderBy(x => x.FechaCreacion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetCajaDetalleById", ex.Message, null);
                throw;
            }
        }

        public void Create(CajaDetalle entity)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    TipoDocumento entityTip = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                    entityTip.NumDoc++;
                    context.SaveChanges();
                    entity.TipoDoc = entityTip.TipoDoc;
                    entity.NumDoc = entityTip.NumDoc;
                    entity.FechaCreacion = DateTimeOffset.Now;
                    context.CajaDetalle.Add(entity);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("Create", ex.Message, null);
                throw;
            }
        }

        public int GetCantidadDetalleCaja(int IdCaja)
        {
            try
            {
                List<CajaDetalle> Lista = context.CajaDetalle.Where(x => x.IdCaja == IdCaja).ToList();
                return Lista.Count;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetCantidadDetalleCaja", ex.Message, null);
                throw;
            }
        }
    }
}