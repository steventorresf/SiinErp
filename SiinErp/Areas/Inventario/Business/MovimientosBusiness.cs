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
        public void Create(Movimientos entityMov, List<MovimientosDetalle> listDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                //IDbContextTransaction Transaccion = context.Database.BeginTransaction();

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
                    entityEt.IdUsuario = entityMov.IdUsuario;
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

                //Transaccion.Commit();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimiento", ex.Message, null);
                throw;
            }
        }

        public void CreateByEntradaCompra(string numFactura, Ordenes entityOrd, Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                IDbContextTransaction Transaccion = context.Database.BeginTransaction();

                TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocEntradaOc));
                tiposdocmov.NumDoc++;
                context.SaveChanges();

                entityMov.TipoDoc = tiposdocmov.TipoDoc;
                entityMov.NumDoc = tiposdocmov.NumDoc;
                entityMov.Transaccion = tiposdocmov.Transaccion;
                entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                entityMov.IdDetAlmacen = entityOrd.IdDetAlmacen;
                entityMov.IdDetCenCosto = entityOrd.IdDetCenCosto;
                entityMov.IdEmpresa = entityOrd.IdEmpresa;
                entityMov.IdTercero = entityOrd.IdProveedor;
                entityMov.Estado = Constantes.EstadoActivo;
                entityMov.FechaCreacion = DateTimeOffset.Now;
                context.Movimientos.Add(entityMov);
                context.SaveChanges();

                decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                Movimientos obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                foreach(MovimientosDetalle m in listaDetalleMov)
                {
                    m.IdMovimiento = obMov.IdMovimiento;
                    vrBruto += m.VrUnitario * m.Cantidad;
                    vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                    vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;
                }

                Facturas factura = new Facturas();
                factura.TipoDoc = entityMov.TipoDoc;
                factura.NumDoc = entityMov.NumDoc;
                factura.Comentario = entityMov.Comentario;
                factura.FechaDoc = entityMov.FechaDoc;
                factura.Periodo = entityMov.Periodo;
                factura.IdDetAlmacen = entityMov.IdDetAlmacen;
                factura.IdDetCenCosto = Convert.ToInt32(entityMov.IdDetCenCosto);
                factura.IdUsuario = entityMov.IdUsuario;
                factura.IdEmpresa = entityMov.IdEmpresa;
                factura.IdMovimiento = obMov.IdMovimiento;
                factura.IdProveedor = Convert.ToInt32(obMov.IdTercero);
                factura.IdOrden = entityOrd.IdOrden;
                factura.IdPlazoPago = entityOrd.IdPlazoPago;
                factura.NumeroCuotas = entityOrd.PlazoPago.Cuotas;
                factura.NumFactura = numFactura;
                factura.PcDscto = 0;
                factura.PcDsctoProntoPago = 0;
                factura.PcInteres = 0;
                factura.PcSeguro = 0;
                factura.ValorBruto = vrBruto;
                factura.ValorDscto = vrDscto;
                factura.ValorFlete = 0;
                factura.ValorIva = vrIva;
                factura.ValorNeto = vrBruto - vrDscto + vrIva;
                factura.ValorNotaCredito = 0;
                factura.ValorNotaDebito = 0;
                factura.ValorOtros = 0;
                factura.ValorPagado = 0;
                factura.ValorSeguro = 0;
                factura.FechaPago = factura.FechaDoc.AddDays(entityOrd.PlazoPago.PlazoDias);
                factura.FechaVencimiento = factura.FechaDoc.AddDays(entityOrd.PlazoPago.PlazoDias);
                factura.Estado = Constantes.EstadoActivo;
                factura.NumRemision = null;                
                factura.FechaCreacion = DateTimeOffset.Now;
                context.Facturas.Add(factura);
                context.SaveChanges();

                List<OrdenesDetalle> listDetalleOrd = context.OrdenesDetalles.Where(x => x.IdOrden == entityOrd.IdOrden).ToList();
                foreach(OrdenesDetalle det in listDetalleOrd)
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

                Transaccion.Commit();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByEntradaCompra", ex.Message, null);
                throw;
            }
        }

        public void CreateByPuntoDeVenta(Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov, List<FacturasFormasDePago> listaDetallePag)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                IDbContextTransaction Transaccion = context.Database.BeginTransaction();

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

                FacturasVen entityFac = new FacturasVen();
                entityFac.TipoDoc = entityMov.TipoDoc;
                entityFac.NumDoc = entityMov.NumDoc;
                entityFac.Comentario = entityMov.Comentario;
                entityFac.FechaDoc = entityMov.FechaDoc;
                entityFac.Periodo = entityMov.Periodo;
                entityFac.IdDetAlmacen = entityMov.IdDetAlmacen;
                entityFac.IdUsuario = entityMov.IdUsuario;
                entityFac.IdEmpresa = entityMov.IdEmpresa;
                entityFac.IdMovimiento = obMov.IdMovimiento;
                entityFac.NumCuotas = 0;
                entityFac.PcDscto = 0;
                entityFac.PcDsctoProntoPago = 0;
                entityFac.PcInteres = 0;
                entityFac.PcSeguro = 0;
                entityFac.ValorBruto = vrBruto;
                entityFac.ValorDscto = vrDscto;
                entityFac.ValorFletes = 0;
                entityFac.ValorIva = vrIva;
                entityFac.ValorNeto = vrBruto - vrDscto + vrIva;
                entityFac.ValorNotaCr = 0;
                entityFac.ValorNotaDb = 0;
                entityFac.ValorOtros = 0;
                entityFac.ValorSaldo = 0;
                entityFac.ValorSeguro = 0;
                entityFac.FechaPago = entityFac.FechaDoc;
                entityFac.FechaVencimiento = entityFac.FechaDoc;
                entityFac.Estado = Constantes.EstadoActivo;
                entityFac.FechaCreacion = DateTimeOffset.Now;
                context.FacturasVen.Add(entityFac);
                context.SaveChanges();

                FacturasVen obFac = context.FacturasVen.FirstOrDefault(x => x.NumDoc == entityFac.NumDoc && x.TipoDoc.Equals(entityFac.TipoDoc));
                foreach(FacturasFormasDePago fp in listaDetallePag)
                {
                    fp.IdFactura = obFac.IdFactura;
                }
                context.FacturasFormasDePagos.AddRange(listaDetallePag);
                context.SaveChanges();

                context.MovimientosDetalles.AddRange(listaDetalleMov);
                context.SaveChanges();

                Transaccion.Commit();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public void CreateByFacturaDeVenta(Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov, FacturasVen entityFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                IDbContextTransaction Transaccion = context.Database.BeginTransaction();

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

                entityFac.TipoDoc = entityMov.TipoDoc;
                entityFac.NumDoc = entityMov.NumDoc;
                entityFac.Periodo = entityMov.Periodo;
                entityFac.IdMovimiento = obMov.IdMovimiento;
                entityFac.ValorBruto = vrBruto;
                entityFac.ValorDscto = vrDscto;
                entityFac.ValorIva = vrIva;
                entityFac.ValorNeto = vrBruto - vrDscto + vrIva;
                entityFac.ValorSaldo = entityFac.PlazoDias > 0 ? entityFac.ValorNeto : 0;
                entityFac.FechaVencimiento = entityFac.FechaDoc.AddDays(entityFac.PlazoDias);
                entityFac.FechaCreacion = DateTimeOffset.Now;
                context.FacturasVen.Add(entityFac);
                context.SaveChanges();

                context.MovimientosDetalles.AddRange(listaDetalleMov);
                context.SaveChanges();

                Transaccion.Commit();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByFacturaDeVenta", ex.Message, null);
                throw;
            }
        }
    }
}
