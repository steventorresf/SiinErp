﻿using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Abstract;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class CajaDetalleBusiness : ICajaDetalleBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public CajaDetalleBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<CajaDetalle> GetCajaDetalleById(int IdCaja)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<CajaDetalle> Lista = (from ca in context.CajaDetalle.Where(x => x.IdCaja == IdCaja && x.Estado.Equals(Constantes.EstadoActivo))
                                           select new CajaDetalle()
                                           {
                                               IdCajaDetalle = ca.IdCajaDetalle,
                                               IdCaja = ca.IdCaja,
                                               IdDetFormaPago = ca.IdDetFormaPago,
                                               IdDetCuenta = ca.IdDetCuenta,
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
