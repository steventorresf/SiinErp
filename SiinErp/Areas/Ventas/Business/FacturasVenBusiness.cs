using SiinErp.Areas.General.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class FacturasVenBusiness
    {
        public int GetLastIdAlmacenPuntoVenta(int idUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                FacturasVen entity = context.FacturasVen.Where(x => x.IdUsuario == idUsuario && x.IdCliente == null)
                                                        .OrderByDescending(x => x.FechaCreacion)
                                                        .FirstOrDefault();
                if (entity != null)
                {
                    return entity.IdDetAlmacen;
                }
                else { return 0; }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetLastIdAlmacenPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public List<FacturasVen> GetPendientesByCli(int IdCliente)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<FacturasVen> Lista = (from f in context.FacturasVen.Where(x => x.IdCliente == IdCliente && x.Estado.Equals(Constantes.EstadoActivo))
                                           select new FacturasVen()
                                           {
                                               IdFactura = f.IdFactura,
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               FechaDoc = f.FechaDoc,
                                               FechaVencimiento = f.FechaVencimiento,
                                               ValorSaldo = f.ValorSaldo,
                                               VrPagar = 0,
                                               ValorDscto = 0,
                                               ValorNeto = 0
                                           }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPendientesByCli", ex.Message, null);
                throw;
            }
        }

        public List<FacturasVen> GetFacturasByFecha(int IdEmpresa, DateTimeOffset Fecha)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<FacturasVen> Lista = (from f in context.FacturasVen.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= Fecha && x.Estado.Equals(Constantes.EstadoActivo))
                                           join c in context.Clientes on f.IdCliente equals c.IdCliente into gj
                                           from LeftJoin in gj.DefaultIfEmpty()
                                           select new FacturasVen()
                                           {
                                               IdFactura = f.IdFactura,
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               IdCliente = f.IdCliente,
                                               IdVendedor = f.IdVendedor,
                                               FechaDoc = f.FechaDoc,
                                               SFechaFormatted = f.FechaDoc.ToString("MM/dd/yyyy"),
                                               ValorNeto = f.ValorNeto,
                                               IdDetAlmacen = f.IdDetAlmacen,
                                               NombreCliente = LeftJoin != null ? LeftJoin.NombreCliente : "",
                                           }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFacturasByFecha", ex.Message, null);
                throw;
            }
        }

        public void Update(FacturasVen entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    FacturasVen obFac = context.FacturasVen.Find(entity.IdFactura);
                    obFac.FechaDoc = entity.FechaDoc;
                    obFac.IdVendedor = entity.IdVendedor;
                    obFac.Comentario = entity.Comentario;
                    context.SaveChanges();

                    Movimientos obMov = context.Movimientos.Find(entity.IdMovimiento);
                    obMov.FechaDoc = entity.FechaDoc;
                    obMov.Comentario = entity.Comentario;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("UpdateFactura", ex.Message, null);
                throw;
            }
        }

        public void Anular(int IdFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    FacturasVen obFac = context.FacturasVen.Find(IdFac);
                    obFac.Estado = Constantes.EstadoInactivo;
                    context.SaveChanges();

                    Movimientos obMov = context.Movimientos.Find(obFac.IdMovimiento);
                    obMov.Estado = Constantes.EstadoInactivo;
                    context.SaveChanges();

                    List<MovimientosDetalle> listDetalle = context.MovimientosDetalles.Where(x => x.IdMovimiento == obFac.IdMovimiento).ToList();
                    foreach(MovimientosDetalle md in listDetalle)
                    {
                        Existencias existencia = context.Existencias.FirstOrDefault(x => x.IdDetAlmacen == obMov.IdDetAlmacen && x.IdArticulo == md.IdArticulo);
                        existencia.Existencia += (md.Cantidad * obMov.Transaccion);
                        context.SaveChanges();
                    }
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("AnularFacturas", ex.Message, null);
                throw;
            }
        }
    }
}
