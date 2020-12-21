using Microsoft.EntityFrameworkCore.Storage;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
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
                    entityMov.CodModulo = Constantes.ModuloInventario;
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

        public void CreateByEntradaCompra(Ordenes entityOrd, Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    TiposDoc tiposdocmov = context.TiposDoc.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.InvDocEntradaOc));
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();
                    entityMov.CodModulo = Constantes.ModuloInventario;
                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.ValorSaldo = entityMov.ValorNeto;
                    entityMov.ValorBruto = entityMov.ValorNeto;
                    entityMov.Transaccion = tiposdocmov.Transaccion;
                    entityMov.FechaVencimiento = entityMov.FechaDoc.AddDays(entityOrd.PlazoPago.PlazoDias);
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
                    entityMov.CodModulo = Constantes.ModuloVentas;
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

                    List<CajaDetalle> ListaCajaDetalle = new List<CajaDetalle>();

                    foreach (MovimientosFormasPago mfp in listaDetallePag)
                    {
                        mfp.IdMovimiento = obMov.IdMovimiento;

                        CajaDetalle entityCajaDet = new CajaDetalle();
                        entityCajaDet.IdCaja = entityMov.IdCaja;
                        entityCajaDet.IdMovimiento = obMov.IdMovimiento;
                        entityCajaDet.TipoDoc = obMov.TipoDoc;
                        entityCajaDet.NumDoc = obMov.NumDoc;
                        entityCajaDet.IdDetFormaPago = mfp.IdDetFormaDePago;
                        entityCajaDet.Efectivo = mfp.Descripcion.Contains("Efectivo") ? true : false;
                        entityCajaDet.Transaccion = 1;
                        entityCajaDet.Valor = mfp.Valor;
                        entityCajaDet.Estado = Constantes.EstadoActivo;
                        entityCajaDet.FechaCreacion = DateTimeOffset.Now;
                        entityCajaDet.CreadoPor = entityMov.CreadoPor;
                        ListaCajaDetalle.Add(entityCajaDet);
                    }
                    context.MovimientosFormasPagos.AddRange(listaDetallePag);
                    context.SaveChanges();

                    context.MovimientosDetalles.AddRange(listaDetalleMov);
                    context.SaveChanges();

                    context.CajaDetalle.AddRange(ListaCajaDetalle);
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
                    entityMov.CodModulo = Constantes.ModuloVentas;
                    entityMov.Transaccion = tiposdocmov.Transaccion;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.IdDetCenCosto = null;
                    entityMov.IdTercero = entityMov.IdTercero;
                    //    entityMov.FechaVencimiento = entityMov.FechaDoc.AddDays(entity.PlazoPago.PlazoDias);
                    entityMov.FechaVencimiento = entityMov.FechaDoc.AddDays(entityMov.PlazoPago.PlazoDias);
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    entityMov.ValorSaldo = entityMov.ValorNeto;
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


        public List<Movimientos> GetMovimientosByModificable(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();

                List<Movimientos> Lista = (from tip in context.TiposDoc
                                           join mov in context.Movimientos.Where(x => x.IdEmpresa == IdEmp && x.CodModulo == Constantes.ModuloVentas && x.Estado.Equals(Constantes.EstadoActivo)) on tip.TipoDoc equals mov.TipoDoc
                                           join ter in context.Terceros on mov.IdTercero equals ter.IdTercero into LeftJoin
                                           from LJ in LeftJoin.DefaultIfEmpty()

                                           select new Movimientos()
                                           {
                                               IdMovimiento = mov.IdMovimiento,
                                               TipoDoc = mov.TipoDoc,
                                               NumDoc = mov.NumDoc,
                                               FechaDoc = mov.FechaDoc,
                                               ValorNeto = mov.ValorNeto,
                                               Estado = mov.Estado,
                                               IdTercero = mov.IdTercero,
                                               IdVendedor = mov.IdVendedor,
                                               IdDetAlmacen = mov.IdDetAlmacen,
                                               NombreTercero = LJ != null ? LJ.NombreTercero : "",
                                           }).OrderByDescending(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetMovimientosByModificable", ex.Message, null);
                throw;
            }
        }


        public List<Movimientos> GetAll(int IdEmp,string Modulo, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimientos> Lista = (from mov in context.Movimientos.Where(x => x.IdEmpresa == IdEmp && x.CodModulo.Equals(Modulo) && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.Estado.Equals(Constantes.EstadoActivo))
                                           join cli in context.Terceros on mov.IdTercero equals cli.IdTercero
                                           join ppa in context.PlazosPagos on cli.IdPlazoPago equals ppa.IdPlazoPago
                                           join tip in context.TiposDoc on mov.TipoDoc equals tip.TipoDoc
                                           join alm in context.TablasDetalles on mov.IdDetAlmacen equals alm.IdDetalle
                                           select new Movimientos()
                                           {
                                               IdMovimiento = mov.IdMovimiento,
                                               TipoDoc = mov.TipoDoc,
                                               NumDoc = mov.NumDoc,
                                               FechaDoc = mov.FechaDoc,
                                               Comentario = mov.Comentario,
                                               Estado = mov.Estado,
                                               IdTercero = mov.IdTercero,
                                               IdDetAlmacen = mov.IdDetAlmacen,
                                               IdDetCenCosto = mov.IdDetCenCosto,
                                               IdDetConcepto = mov.IdDetConcepto,
                                               NombreAlmacen = alm.Descripcion,
                                               ValorNeto = mov.ValorNeto,
                                               NombreTercero = cli.NombreTercero,
                                               IdVendedor = mov.IdVendedor,
                                               FechaVencimiento = mov.FechaVencimiento,
                                               NumFactura = mov.NumFactura,
                                               PlazoPago = ppa,
                                           }).OrderByDescending(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
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
                List<Movimientos> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.IdTercero == IdTercero && x.Estado.Equals(Constantes.EstadoActivo))

                                           select new Movimientos()
                                           {
                                               IdMovimiento = f.IdMovimiento,
                                               TipoDoc = f.TipoDoc,
                                               NumDoc = f.NumDoc,
                                               NumFactura = f.NumFactura,
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
                ErroresBusiness.Create("GetPendientesByTercero", ex.Message, null);
                throw;
            }
        }

        public List<Movimientos> GetFacturasByRangoFecha(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimientos> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.CodModulo.Equals(Constantes.ModuloVentas) && x.Estado.Equals(Constantes.EstadoActivo))
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

        public void Anular(int Id)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Movimientos entityMov = context.Movimientos.Find(Id);
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
                ErroresBusiness.Create("Anular", ex.Message, null);
                throw;
            }
        }

        public int getLastAlmacenByUsu(string nombreUsuario, int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Movimientos entity = context.Movimientos.Where(x => x.CreadoPor.Equals(nombreUsuario) && x.IdEmpresa == IdEmpresa)
                                                        .OrderByDescending(x => x.FechaCreacion).FirstOrDefault();
                return entity != null ? entity.IdDetAlmacen : -1;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("getLastAlmacenByUsu", ex.Message, null);
                throw;
            }
        }
        #endregion


        #region Impresión
        public Movimientos Imprimir(int IdMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Movimientos entity = context.Movimientos.Find(IdMov);
                entity.sFechaFormatted = entity.FechaDoc.ToString("dd/MM/yyyy");
                entity.NoDoc = entity.TipoDoc + entity.NumDoc;
                entity.sFechaVen = entity.FechaVencimiento.ToString("dd/MM/yyyy");                

                if(entity.IdEmpresa > 0)
                {
                    Empresas entityEmpresa = context.Empresas.Find(entity.IdEmpresa);
                    entity.NombreEmpresa = entityEmpresa.RazonSocial;
                }

                if(entity.IdDetAlmacen > 0)
                {
                    TablasDetalle entityAlmacen = context.TablasDetalles.Find(entity.IdDetAlmacen);
                    entity.NombreAlmacen = entityAlmacen.Descripcion;
                }

                if (entity.IdDetConcepto != null && entity.IdDetConcepto > 0)
                {
                    TablasDetalle entityConcepto = context.TablasDetalles.Find(entity.IdDetConcepto);
                    entity.NombreConcepto = entityConcepto.Descripcion;
                }

                if(entity.IdDetCenCosto != null && entity.IdDetCenCosto > 0)
                {
                    TablasDetalle entityCentroCosto = context.TablasDetalles.Find(entity.IdDetCenCosto);
                    entity.NombreCentroCosto = entityCentroCosto.Descripcion;
                }

                if (entity.IdTercero != null && entity.IdTercero > 0)
                {
                    TablasDetalle entityTercero = context.TablasDetalles.Find(entity.IdTercero);
                    entity.NombreTercero = entityTercero.Descripcion;
                }

                if (entity.IdVendedor != null && entity.IdVendedor > 0)
                {
                    Vendedores entityVendedor = context.Vendedores.Find(entity.IdVendedor);
                    entity.NombreVendedor = entityVendedor.NombreVendedor;
                }

                entity.ListaDetalle = (from d in context.MovimientosDetalles.Where(x => x.IdMovimiento == IdMov)
                                       join a in context.Articulos on d.IdArticulo equals a.IdArticulo
                                       select new MovimientosDetalle()
                                       {
                                           IdDetalleMovimiento = d.IdDetalleMovimiento,
                                           IdMovimiento = d.IdMovimiento,
                                           IdArticulo = d.IdArticulo,
                                           Cantidad = d.Cantidad,
                                           PcDscto = d.PcDscto,
                                           VrBruto = d.VrBruto,
                                           PcIva = d.PcIva,
                                           VrCosto = d.VrCosto,
                                           VrNeto = d.VrNeto,
                                           VrUnitario = d.VrUnitario,
                                           NombreArticulo = a.NombreArticulo,
                                           Articulo = a,
                                           CodArticulo = a.CodArticulo
                                       }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ImprimirMovimiento", ex.Message, null);
                throw;
            }
        }
        #endregion
    }
}
