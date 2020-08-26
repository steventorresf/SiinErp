using Microsoft.EntityFrameworkCore.Storage;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Inventario.Business
{
    public class MovimientosBusiness
    {

        #region Inventario
        public void Create(Movimientos entityMov, List<MovimientosDetalle> listDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var transaction = context.Database.BeginTransaction())
                {
                    TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(entityMov.TipoDoc) && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    Movimientos obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc) && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                    foreach (MovimientosDetalle m in listDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                    }

                    context.MovimientosDetalles.AddRange(listDetalleMov);
                    context.SaveChanges();


                    if (entityMov.TipoDoc.Equals(Constantes.InvDocTraslados) && entityMov.IdDetAlmDestino != null)
                    {
                        TiposDoc tipodoc2 = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocEntradaTraslado) && x.IdDetAlmacen == entityMov.IdDetAlmDestino);
                        tipodoc2.NumDoc++;
                        context.SaveChanges();

                        Movimientos entityEt = new Movimientos();
                        entityEt.TipoDoc = Constantes.InvDocEntradaTraslado;
                        entityEt.NumDoc = tipodoc2.NumDoc;
                        entityEt.IdDetAlmacen = Convert.ToInt32(entityMov.IdDetAlmDestino);
                        entityEt.IdDetAlmDestino = entityMov.IdDetAlmacen;
                        entityEt.IdEmpresa = entityMov.IdEmpresa;
                        entityEt.CreadoPor = entityMov.CreadoPor;
                        entityEt.Estado = entityMov.Estado;
                        entityEt.FechaDoc = entityMov.FechaDoc;
                        entityEt.Periodo = entityMov.Periodo;
                        entityEt.IdTercero = entityMov.IdTercero;
                        entityEt.Comentario = entityMov.Comentario;
                        entityEt.IdDetCenCosto = entityMov.IdDetCenCosto;
                        entityEt.IdDetConcepto = entityMov.IdDetConcepto;
                        entityEt.Transaccion = 1;
                        entityEt.FechaCreacion = DateTimeOffset.Now;
                        context.Movimientos.Add(entityEt);
                        context.SaveChanges();

                        Movimientos ob = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityEt.NumDoc && x.TipoDoc.Equals(entityEt.TipoDoc) && x.IdDetAlmacen == entityEt.IdDetAlmacen);
                        List<MovimientosDetalle> listDetalleMov2 = new List<MovimientosDetalle>();
                        foreach (MovimientosDetalle m in listDetalleMov)
                        {
                            MovimientosDetalle det = new MovimientosDetalle();
                            det.IdMovimiento = ob.IdMovimiento;
                            det.IdArticulo = m.IdArticulo;
                            det.Cantidad = m.Cantidad;
                            det.VrCosto = m.VrCosto;
                            det.VrUnitario = m.VrUnitario;
                            det.PcDscto = m.PcDscto;
                            det.PcIva = m.PcIva;
                            listDetalleMov2.Add(det);
                        }

                        context.MovimientosDetalles.AddRange(listDetalleMov2);
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimiento", ex.Message, null);
                throw;
            }
        }

        public void CreateByEntradaCompra(Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocEntradaOc));
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();
                    entityMov.CodModulo = Constantes.ModuloCompras;
                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.Transaccion = tiposdocmov.Transaccion;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                    Movimientos obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientosDetalle m in listaDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                        vrBruto += m.VrUnitario * m.Cantidad;
                        vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                        vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;
                    }


                    List<OrdenesDetalle> listDetalleOrd = context.OrdenesDetalles.Where(x => x.IdOrden == entityMov.IdOrden).ToList();
                    foreach (OrdenesDetalle det in listDetalleOrd)
                    {
                        MovimientosDetalle movdet = listaDetalleMov.FirstOrDefault(x => x.IdArticulo == det.IdArticulo);
                        if (movdet != null)
                        {
                            det.CantidadEje += movdet.Cantidad;
                        }
                    }
                    context.SaveChanges();

                    context.MovimientosDetalles.AddRange(listaDetalleMov);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByEntradaCompra", ex.Message, null);
                throw;
            }
        }

        public void CreateByPuntoDeVenta(Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov, List<MovimientosFormasPago> listaDetallePag)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var transaccion = context.Database.BeginTransaction())
                {
                    TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocFacturaPuntoVenta) && x.IdDetAlmacen == entityMov.IdDetAlmacen && x.IdEmpresa == entityMov.IdEmpresa);
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.Transaccion = tiposdocmov.Transaccion;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.IdDetCenCosto = null;
                    entityMov.IdTercero = null;
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                    Movimientos obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientosDetalle m in listaDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                        vrBruto += m.VrUnitario * m.Cantidad;
                        vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                        vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;
                    }

                    foreach (MovimientosFormasPago mfp in listaDetallePag)
                    {
                        mfp.IdMovimiento = obMov.IdMovimiento;
                    }
                    context.MovimientosFormasPagos.AddRange(listaDetallePag);
                    context.SaveChanges();

                    context.MovimientosDetalles.AddRange(listaDetalleMov);
                    context.SaveChanges();

                    transaccion.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public void CreateByFacturaDeVenta(Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var transaccion = context.Database.BeginTransaction())
                {
                    TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocFacturaVenta) && x.IdDetAlmacen == entityMov.IdDetAlmacen && x.IdEmpresa == entityMov.IdEmpresa);
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.Transaccion = tiposdocmov.Transaccion;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.IdDetCenCosto = null;
                    entityMov.IdTercero = null;
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                    Movimientos obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientosDetalle m in listaDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                        vrBruto += m.VrUnitario * m.Cantidad;
                        vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                        vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;
                    }

                    context.MovimientosDetalles.AddRange(listaDetalleMov);
                    context.SaveChanges();

                    transaccion.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByFacturaDeVenta", ex.Message, null);
                throw;
            }
        }


        public List<Movimientos> GetMovimientosByModificable(DateTime Fecha)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimientos> Lista = (from tip in context.TiposDoc
                                           join mov in context.Movimientos.Where(x => x.FechaDoc >= Fecha && x.Estado.Equals(Constantes.EstadoActivo)) on tip.TipoDoc equals mov.TipoDoc
                                           join alm in context.TablasEmpresaDetalles on mov.IdDetAlmacen equals alm.IdDetalle
                                           select new Movimientos()
                                           {
                                               IdMovimiento = mov.IdMovimiento,
                                               TipoDoc = mov.TipoDoc,
                                               NumDoc = mov.NumDoc,
                                               FechaDoc = mov.FechaDoc,
                                               Comentario = mov.Comentario,
                                               Estado = mov.Estado,
                                               IdDetAlmacen = mov.IdDetAlmacen,
                                               NombreAlmacen = alm.Descripcion,
                                           }).OrderByDescending(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch(Exception ex)
            {
                ErroresBusiness.Create("GetMovimientosByModificable", ex.Message, null);
                throw;
            }
        }

        #endregion

        #region Facturas Ventas Y Compras
        public List<Movimientos> GetPendientesByTercero(int IdEmpresa, int IdTercero)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimientos> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa &&  x.IdTercero == IdTercero && x.Estado.Equals(Constantes.EstadoActivo))
               
                                                                       select new Movimientos()
                                           {
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               FechaDoc = f.FechaDoc,
                                               FechaVencimiento = f.FechaVencimiento,
                                               ValorSaldo = f.ValorNeto - f.ValorPagado,
                                               VrPagar = 0,
                                               ValorDscto = 0,
                                               ValorNeto = 0
                                           }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPendientesByTercero", ex.Message, null);
                throw;
            }
        }

        public List<Movimientos> GetFacturasByFecha(int IdEmpresa, DateTimeOffset Fecha)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimientos> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= Fecha && x.CodModulo.Equals(Constantes.ModuloVentas) && x.Estado.Equals(Constantes.EstadoActivo))
                                           join c in context.Terceros on f.IdTercero equals c.IdTercero into LeftJoin
                                           from LJ in LeftJoin.DefaultIfEmpty()
                                           select new Movimientos()
                                           {
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               IdTercero = f.IdTercero,
                                               IdVendedor = f.IdVendedor,
                                               FechaDoc = f.FechaDoc,
                                               sFechaFormatted = f.FechaDoc.ToString("MM/dd/yyyy"),
                                               ValorNeto = f.ValorNeto,
                                               IdDetAlmacen = f.IdDetAlmacen,
                                               NombreTercero = LJ != null ? LJ.NombreTercero : "",
                                           }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFacturasByFecha", ex.Message, null);
                throw;
            }
        }

        public void UpdateFactura(Movimientos entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Movimientos obFac = context.Movimientos.Find(entity.IdMovimiento);
                    obFac.FechaDoc = entity.FechaDoc;
                    obFac.IdVendedor = entity.IdVendedor;
                    obFac.Comentario = entity.Comentario;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateFactura", ex.Message, null);
                throw;
            }
        }

        public void AnularFactura(int IdFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Movimientos entityMov = context.Movimientos.Find(IdFac);
                    entityMov.Estado = Constantes.EstadoInactivo;
                    context.SaveChanges();

                    List<MovimientosDetalle> listDetalle = context.MovimientosDetalles.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientosDetalle md in listDetalle)
                    {
                        Existencias existencia = context.Existencias.FirstOrDefault(x => x.IdDetAlmacen == entityMov.IdDetAlmacen && x.IdArticulo == md.IdArticulo);
                        existencia.Existencia += (md.Cantidad * entityMov.Transaccion * -1);
                        context.SaveChanges();
                    }
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("AnularFactura", ex.Message, null);
                throw;
            }
        }
        #endregion
    }
}
