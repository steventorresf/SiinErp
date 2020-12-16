using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class CajaDetalleBusiness
    {
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
                ErroresBusiness.Create("GetCajaDetalleById", ex.Message, null);
                throw;
            }
        }


        public void Create(CajaDetalle entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;

                SiinErpContext context = new SiinErpContext();
                context.CajaDetalle.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateCajaDetalle", ex.Message, null);
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
                ErroresBusiness.Create("GetCantidadDetalleCaja", ex.Message, null);
                throw;
            }
        }

    }
}
