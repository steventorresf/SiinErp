using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Abstract;
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
    public class MovimientoBusiness : IMovimientoBusiness
    {
        private readonly IMovimientoDetalleBusiness movimientoDetalleBusiness;
        private readonly IMovimientoFormaPagoBusiness movimientoFormaPagoBusiness;
        private readonly IErrorBusiness errorBusiness;

        public MovimientoBusiness()
        {
            movimientoDetalleBusiness = new MovimientoDetalleBusiness();
            movimientoFormaPagoBusiness = new MovimientoFormaPagoBusiness();
            errorBusiness = new ErrorBusiness();
        }



        #region Inventario
        public void Create(Movimiento entityMov, List<MovimientoDetalle> listDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var transaction = context.Database.BeginTransaction())
                {
                    TipoDocumento tiposdocmov = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entityMov.TipoDoc));
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.CodModulo = Constantes.ModuloInventario;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    Movimiento obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc) && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                    foreach (MovimientoDetalle m in listDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                    }

                    context.MovimientosDetalles.AddRange(listDetalleMov);
                    context.SaveChanges();


                    if (entityMov.TipoDoc.Equals(Constantes.TipoDocEntradaTraslado) && entityMov.IdDetAlmDestino != null)
                    {
                        TipoDocumento tipodoc2 = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.TipoDocEntradaTraslado));
                        tipodoc2.NumDoc++;
                        context.SaveChanges();

                        Movimiento entityEt = new Movimiento();
                        entityEt.TipoDoc = Constantes.TipoDocEntradaTraslado;
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

                        Movimiento ob = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityEt.NumDoc && x.TipoDoc.Equals(entityEt.TipoDoc) && x.IdDetAlmacen == entityEt.IdDetAlmacen);
                        List<MovimientoDetalle> listDetalleMov2 = new List<MovimientoDetalle>();
                        foreach (MovimientoDetalle m in listDetalleMov)
                        {
                            MovimientoDetalle det = new MovimientoDetalle();
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
                errorBusiness.Create("CreateMovimiento", ex.Message, null);
                throw;
            }
        }

        public void CreateByEntradaCompra(Orden entityOrd, Movimiento entityMov, List<MovimientoDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    TipoDocumento tiposdocmov = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.TipoDocEntradaOc));
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();
                    entityMov.CodModulo = Constantes.ModuloInventario;
                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.ValorSaldo = entityMov.ValorNeto;
                    entityMov.ValorBruto = entityMov.ValorNeto;
                    entityMov.Transaccion = tiposdocmov.IdDetTransaccion;
                    entityMov.FechaVencimiento = entityMov.FechaDoc.AddDays(entityOrd.PlazoPago.PlazoDias);
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                    Movimiento obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientoDetalle m in listaDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                        vrBruto += m.VrUnitario * m.Cantidad;
                        vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                        vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;
                    }


                    List<OrdenDetalle> listDetalleOrd = context.OrdenesDetalles.Where(x => x.IdOrden == entityMov.IdOrden).ToList();
                    foreach (OrdenDetalle det in listDetalleOrd)
                    {
                        MovimientoDetalle movdet = listaDetalleMov.FirstOrDefault(x => x.IdArticulo == det.IdArticulo);
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
                errorBusiness.Create("CreateMovimientoByEntradaCompra", ex.Message, null);
                throw;
            }
        }

        public int CreateByPuntoDeVenta(JObject data)
        {
            try
            {
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listaDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();
                List<MovimientoFormaPago> listaDetallePag = data["listDetallePag"].ToObject<List<MovimientoFormaPago>>();

                SiinErpContext context = new SiinErpContext();
                using (var transaccion = context.Database.BeginTransaction())
                {
                    TipoDocumento tiposdocmov = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entityMov.TipoDoc) && x.IdEmpresa == entityMov.IdEmpresa);
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.CodModulo = Constantes.ModuloVentas;
                    entityMov.Transaccion = tiposdocmov.IdDetTransaccion;
                    entityMov.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMov.Estado = Constantes.EstadoActivo;
                    entityMov.FechaVencimiento = entityMov.PlazoPago == null ? entityMov.FechaDoc : entityMov.FechaDoc.AddDays(entityMov.PlazoPago.PlazoDias);
                    entityMov.FechaCreacion = DateTimeOffset.Now;
                    context.Movimientos.Add(entityMov);
                    context.SaveChanges();

                    decimal vrBruto = 0, vrDscto = 0, vrIva = 0;

                    Movimiento obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientoDetalle m in listaDetalleMov)
                    {
                        m.IdMovimiento = obMov.IdMovimiento;
                        vrBruto += m.VrUnitario * m.Cantidad;
                        vrDscto += m.VrUnitario * m.Cantidad * m.PcDscto / 100;
                        vrIva += m.VrUnitario * m.Cantidad * m.PcIva / 100;

                        ArticuloExistencia entityExist = context.Existencias.FirstOrDefault(x => x.IdArticulo == m.IdArticulo && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                        if (entityExist == null)
                        {
                            entityExist = new ArticuloExistencia();
                            entityExist.IdEmpresa = entityMov.IdEmpresa;
                            entityExist.IdDetAlmacen = entityMov.IdDetAlmacen;
                            entityExist.IdArticulo = m.IdArticulo;
                            entityExist.Existencia = m.Cantidad * -1;
                            context.Existencias.Add(entityExist);
                            context.SaveChanges();
                        }
                        else
                        {
                            entityExist.Existencia += m.Cantidad * -1;
                            context.SaveChanges();
                        }
                    }

                    List<CajaDetalle> ListaCajaDetalle = new List<CajaDetalle>();

                    foreach (MovimientoFormaPago mfp in listaDetallePag)
                    {
                        mfp.IdMovimiento = obMov.IdMovimiento;

                        CajaDetalle entityCajaDet = new CajaDetalle();
                        entityCajaDet.IdCaja = Convert.ToInt32(entityMov.IdCaja);
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

                    if(entityMov.IdTercero != null)
                    {
                        Tercero entityCli = context.Terceros.Find(entityMov.IdTercero);
                        entityCli.Direccion = entityMov.DireccionTercero;
                        entityCli.Telefono = entityMov.TelefonoTercero;
                        context.SaveChanges();
                    }

                    transaccion.Commit();

                    return obMov.IdMovimiento;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateMovimientoByPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public int UpdateByPuntoDeVenta(JObject data)
        {
            try
            {
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listaDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();
                List<MovimientoFormaPago> listaDetallePag = data["listDetallePag"].ToObject<List<MovimientoFormaPago>>();

                SiinErpContext context = new SiinErpContext();
                using (var transaccion = context.Database.BeginTransaction())
                {
                    Movimiento entityMovBD = context.Movimientos.Find(entityMov.IdMovimiento);
                    entityMovBD.IdTercero = entityMov.IdTercero;
                    entityMovBD.IdPlazoPago = entityMov.IdPlazoPago;
                    entityMovBD.IdListaPrecio = entityMov.IdListaPrecio;
                    entityMovBD.FechaDoc = entityMov.FechaDoc;
                    entityMovBD.Periodo = entityMov.FechaDoc.ToString("yyyyMM");
                    entityMovBD.FechaVencimiento = entityMov.PlazoPago == null ? entityMov.FechaDoc : entityMov.FechaDoc.AddDays(entityMov.PlazoPago.PlazoDias);
                    entityMovBD.ValorBruto = entityMov.ValorBruto;
                    entityMovBD.ValorDscto = entityMov.ValorDscto;
                    entityMovBD.ValorIva = entityMov.ValorIva;
                    entityMovBD.ValorNeto = entityMov.ValorNeto;
                    entityMovBD.ModificadoPor = entityMov.ModificadoPor;
                    entityMovBD.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    List<MovimientoDetalle> listaDetalleMovBD = context.MovimientosDetalles.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientoDetalle m in listaDetalleMovBD)
                    {
                        MovimientoDetalle entityDetalle = listaDetalleMov.FirstOrDefault(x => x.IdDetalleMovimiento == m.IdDetalleMovimiento);
                        if (entityDetalle == null)
                        {
                            context.MovimientosDetalles.Remove(m);
                            context.SaveChanges();

                            ArticuloExistencia entityExist = context.Existencias.FirstOrDefault(x => x.IdArticulo == m.IdArticulo && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                            if (entityExist != null)
                            {
                                entityExist.Existencia += m.Cantidad;
                                context.SaveChanges();
                            }
                        }
                    }

                    listaDetalleMovBD = context.MovimientosDetalles.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientoDetalle m in listaDetalleMov)
                    {
                        ArticuloExistencia entityExist = context.Existencias.FirstOrDefault(x => x.IdArticulo == m.IdArticulo && x.IdDetAlmacen == entityMov.IdDetAlmacen);
                        MovimientoDetalle entityDetalle = listaDetalleMovBD.FirstOrDefault(x => x.IdDetalleMovimiento == m.IdDetalleMovimiento);
                        if (entityDetalle == null)
                        {
                            m.IdMovimiento = entityMov.IdMovimiento;
                            context.MovimientosDetalles.Add(m);
                            context.SaveChanges();

                            if (entityExist == null)
                            {
                                entityExist = new ArticuloExistencia();
                                entityExist.IdEmpresa = entityMov.IdEmpresa;
                                entityExist.IdDetAlmacen = entityMov.IdDetAlmacen;
                                entityExist.IdArticulo = m.IdArticulo;
                                entityExist.Existencia = m.Cantidad * entityMov.Transaccion;
                                context.Existencias.Add(entityExist);
                                context.SaveChanges();
                            }
                            else
                            {
                                entityExist.Existencia += m.Cantidad * entityMov.Transaccion;
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            if (entityExist != null)
                            {
                                entityExist.Existencia += entityDetalle.Cantidad - m.Cantidad;
                                context.SaveChanges();
                            }

                            entityDetalle.Cantidad = m.Cantidad;
                            entityDetalle.PcDscto = m.PcDscto;
                            entityDetalle.PcIva = m.PcIva;
                            entityDetalle.VrUnitario = m.VrUnitario;
                            entityDetalle.VrCosto = m.VrCosto;
                            entityDetalle.VrBruto = m.VrBruto;
                            entityDetalle.VrNeto = m.VrNeto;
                            context.SaveChanges();
                        }
                    }

                    List<MovimientoFormaPago> listaDetallePagDB = context.MovimientosFormasPagos.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientoFormaPago m in listaDetallePagDB)
                    {
                        MovimientoFormaPago entityFormaPag = listaDetallePag.FirstOrDefault(x => x.IdDetFormaDePago == m.IdDetFormaDePago && x.Valor > 0);
                        if (entityFormaPag == null)
                        {
                            context.MovimientosFormasPagos.Remove(m);
                            context.SaveChanges();

                            CajaDetalle entityCajaDet = context.CajaDetalle.FirstOrDefault(x => x.IdMovimiento == m.IdMovimiento && x.IdCaja == entityMov.IdCaja && x.IdDetFormaPago == m.IdDetFormaDePago);
                            if (entityCajaDet != null)
                            {
                                context.CajaDetalle.Remove(entityCajaDet);
                                context.SaveChanges();
                            }
                        }
                    }

                    listaDetallePagDB = context.MovimientosFormasPagos.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientoFormaPago mfp in listaDetallePag)
                    {
                        MovimientoFormaPago entityFormaPag = listaDetallePagDB.FirstOrDefault(x => x.IdDetFormaDePago == mfp.IdDetFormaDePago);
                        if (entityFormaPag == null)
                        {
                            mfp.IdMovimiento = entityMov.IdMovimiento;
                            context.MovimientosFormasPagos.Add(mfp);
                            context.SaveChanges();

                            if(entityMov.IdCaja != null)
                            {
                                CajaDetalle entityCajaDet = new CajaDetalle();
                                entityCajaDet.IdCaja = Convert.ToInt32(entityMov.IdCaja);
                                entityCajaDet.IdMovimiento = entityMov.IdMovimiento;
                                entityCajaDet.TipoDoc = entityMov.TipoDoc;
                                entityCajaDet.NumDoc = entityMov.NumDoc;
                                entityCajaDet.IdDetFormaPago = mfp.IdDetFormaDePago;
                                entityCajaDet.Efectivo = mfp.Descripcion.Contains("Efectivo") ? true : false;
                                entityCajaDet.Transaccion = 1;
                                entityCajaDet.Valor = mfp.Valor;
                                entityCajaDet.Estado = Constantes.EstadoActivo;
                                entityCajaDet.FechaCreacion = DateTimeOffset.Now;
                                entityCajaDet.CreadoPor = entityMov.ModificadoPor;
                                context.CajaDetalle.Add(entityCajaDet);
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            entityFormaPag.Valor = mfp.Valor;
                            context.SaveChanges();

                            CajaDetalle entityCajaDet = context.CajaDetalle.FirstOrDefault(x => x.IdMovimiento == mfp.IdMovimiento && x.IdCaja == entityMov.IdCaja && x.IdDetFormaPago == mfp.IdDetFormaDePago);
                            if (entityCajaDet != null)
                            {
                                entityCajaDet.Valor = mfp.Valor;
                                entityCajaDet.ModificadoPor = entityMov.ModificadoPor;
                                entityCajaDet.FechaModificado = DateTimeOffset.Now;
                                context.SaveChanges();
                            }
                        }
                    }

                    if (entityMov.IdTercero != null)
                    {
                        Tercero entityCli = context.Terceros.Find(entityMov.IdTercero);
                        entityCli.NombreTercero = entityMov.NombreTercero;
                        entityCli.Direccion = entityMov.DireccionTercero;
                        entityCli.Telefono = entityMov.TelefonoTercero;
                        context.SaveChanges();
                    }

                    transaccion.Commit();

                    return entityMov.IdMovimiento;
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateMovimientoByPuntoVenta", ex.Message, null);
                throw;
            }
        }

        public void CreateByFacturaDeVenta(JObject data)
        {
            try
            {
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listaDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();

                SiinErpContext context = new SiinErpContext();
                using (var transaccion = context.Database.BeginTransaction())
                {
                    TipoDocumento tiposdocmov = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(Constantes.TipoDocFacturaVenta) && x.IdEmpresa == entityMov.IdEmpresa);
                    tiposdocmov.NumDoc++;
                    context.SaveChanges();

                    entityMov.TipoDoc = tiposdocmov.TipoDoc;
                    entityMov.NumDoc = tiposdocmov.NumDoc;
                    entityMov.CodModulo = Constantes.ModuloVentas;
                    entityMov.Transaccion = tiposdocmov.IdDetTransaccion;
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

                    Movimiento obMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == entityMov.NumDoc && x.TipoDoc.Equals(entityMov.TipoDoc));
                    foreach (MovimientoDetalle m in listaDetalleMov)
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
                errorBusiness.Create("CreateMovimientoByFacturaDeVenta", ex.Message, null);
                throw;
            }
        }

        public Movimiento GetByDocumento(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                string TipoDoc = data["tipoDoc"].ToObject<string>();
                int NumDoc = data["numDoc"].ToObject<int>();

                SiinErpContext context = new SiinErpContext();
                Movimiento entityMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == NumDoc && x.TipoDoc.Equals(TipoDoc) && x.IdEmpresa == IdEmpresa);

                if (entityMov != null)
                {
                    entityMov.VrRestante = entityMov.ValorNeto;
                    entityMov.sFechaFormatted = entityMov.FechaDoc.ToString("MM/dd/yyyy");
                    if (entityMov.IdTercero != null)
                    {
                        Tercero entityTer = context.Terceros.Find(entityMov.IdTercero);
                        entityMov.NitCedula = entityTer.NitCedula;
                        entityMov.NombreTercero = entityTer.NombreTercero;
                        entityMov.DireccionTercero = entityTer.Direccion;
                        entityMov.TelefonoTercero = entityTer.Telefono;
                    }

                    entityMov.ListaDetalle = movimientoDetalleBusiness.GetMovimientosDetalles(entityMov.IdMovimiento);
                    entityMov.ListaFormaPago = movimientoFormaPagoBusiness.GetMovimientoFormasPago(entityMov.IdMovimiento);
                }

                return entityMov;
            }
            catch(Exception ex)
            {
                errorBusiness.Create("GetByDocumento", ex.Message, null);
                throw;
            }
        }


        public List<Movimiento> GetMovimientosByModificable(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();

                List<Movimiento> Lista = (from tip in context.TiposDocumentos
                                          join mov in context.Movimientos.Where(x => x.IdEmpresa == IdEmp && x.CodModulo == Constantes.ModuloVentas && x.Estado.Equals(Constantes.EstadoActivo)) on tip.TipoDoc equals mov.TipoDoc
                                          join ter in context.Terceros on mov.IdTercero equals ter.IdTercero into LeftJoin
                                          from LJ in LeftJoin.DefaultIfEmpty()
                                          select new Movimiento()
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
                errorBusiness.Create("GetMovimientosByModificable", ex.Message, null);
                throw;
            }
        }


        public List<Movimiento> GetAll(int IdEmp,string Modulo, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimiento> Lista = (from mov in context.Movimientos.Where(x => x.IdEmpresa == IdEmp && x.TipoDoc.Equals(Constantes.TipoDocFacturaVenta) && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.Estado.Equals(Constantes.EstadoActivo))
                                          join cli in context.Terceros on mov.IdTercero equals cli.IdTercero
                                          join ppa in context.PlazosPagos on mov.IdPlazoPago equals ppa.IdPlazoPago
                                          join tip in context.TiposDocumentos on mov.TipoDoc equals tip.TipoDoc
                                          join alm in context.TablasDetalles on mov.IdDetAlmacen equals alm.IdDetalle
                                          select new Movimiento()
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
                                              IdPlazoPago = mov.IdPlazoPago,
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
                errorBusiness.Create("GetMovimientosByModificable", ex.Message, null);
                throw;
            }
        }

        #endregion

        #region Facturas Ventas Y Compras
        public List<Movimiento> GetPendientesByTercero(int IdEmpresa, int IdTercero)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimiento> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.IdTercero == IdTercero && x.Estado.Equals(Constantes.EstadoActivo))

                                           select new Movimiento()
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
                errorBusiness.Create("GetPendientesByTercero", ex.Message, null);
                throw;
            }
        }

        public List<Movimiento> GetFacturasByRangoFecha(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Movimiento> Lista = (from f in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.CodModulo.Equals(Constantes.ModuloVentas) && x.Estado.Equals(Constantes.EstadoActivo))
                                           join c in context.Terceros on f.IdTercero equals c.IdTercero into LeftJoin
                                           from LJ in LeftJoin.DefaultIfEmpty()
                                           select new Movimiento()
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
                errorBusiness.Create("GetFacturasByFecha", ex.Message, null);
                throw;
            }
        }

        public void UpdateFactura(Movimiento entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Movimiento obFac = context.Movimientos.Find(entity.IdMovimiento);
                    obFac.FechaDoc = entity.FechaDoc;
                    obFac.IdVendedor = entity.IdVendedor;
                    obFac.Comentario = entity.Comentario;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateFactura", ex.Message, null);
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
                    Movimiento entityMov = context.Movimientos.Find(Id);
                    entityMov.Estado = Constantes.EstadoInactivo;
                    context.SaveChanges();

                    List<MovimientoDetalle> listDetalle = context.MovimientosDetalles.Where(x => x.IdMovimiento == entityMov.IdMovimiento).ToList();
                    foreach (MovimientoDetalle md in listDetalle)
                    {
                        ArticuloExistencia existencia = context.Existencias.FirstOrDefault(x => x.IdDetAlmacen == entityMov.IdDetAlmacen && x.IdArticulo == md.IdArticulo);
                        existencia.Existencia += (md.Cantidad * entityMov.Transaccion * -1);
                        context.SaveChanges();
                    }
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("Anular", ex.Message, null);
                throw;
            }
        }

        public int getLastAlmacenByUsu(string nombreUsuario, int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Movimiento entity = context.Movimientos.Where(x => x.CreadoPor.Equals(nombreUsuario) && x.IdEmpresa == IdEmpresa)
                                                        .OrderByDescending(x => x.FechaCreacion).FirstOrDefault();
                return entity != null ? entity.IdDetAlmacen : -1;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("getLastAlmacenByUsu", ex.Message, null);
                throw;
            }
        }
        #endregion


        #region Impresión
        public Movimiento Imprimir(int IdMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Movimiento entity = context.Movimientos.Find(IdMov);
                entity.sFechaFormatted = entity.FechaDoc.ToString("dd/MM/yyyy");
                entity.NoDoc = entity.TipoDoc + entity.NumDoc;
                entity.sFechaVen = entity.FechaVencimiento.ToString("dd/MM/yyyy");                

                if(entity.IdEmpresa > 0)
                {
                    Empresa entityEmpresa = context.Empresas.Find(entity.IdEmpresa);
                    entity.NombreEmpresa = entityEmpresa.RazonSocial;
                }

                if(entity.IdDetAlmacen > 0)
                {
                    TablaDetalle entityAlmacen = context.TablasDetalles.Find(entity.IdDetAlmacen);
                    entity.NombreAlmacen = entityAlmacen.Descripcion;
                }

                if (entity.IdDetConcepto != null && entity.IdDetConcepto > 0)
                {
                    TablaDetalle entityConcepto = context.TablasDetalles.Find(entity.IdDetConcepto);
                    entity.NombreConcepto = entityConcepto.Descripcion;
                }

                if(entity.IdDetCenCosto != null && entity.IdDetCenCosto > 0)
                {
                    TablaDetalle entityCentroCosto = context.TablasDetalles.Find(entity.IdDetCenCosto);
                    entity.NombreCentroCosto = entityCentroCosto.Descripcion;
                }

                if (entity.IdTercero != null && entity.IdTercero > 0)
                {
                    TablaDetalle entityTercero = context.TablasDetalles.Find(entity.IdTercero);
                    entity.NombreTercero = entityTercero.Descripcion;
                }

                if (entity.IdVendedor != null && entity.IdVendedor > 0)
                {
                    Vendedor entityVendedor = context.Vendedores.Find(entity.IdVendedor);
                    entity.NombreVendedor = entityVendedor.NombreVendedor;
                }

                entity.ListaDetalle = (from d in context.MovimientosDetalles.Where(x => x.IdMovimiento == IdMov)
                                       join a in context.Articulos on d.IdArticulo equals a.IdArticulo
                                       select new MovimientoDetalle()
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
                errorBusiness.Create("ImprimirMovimiento", ex.Message, null);
                throw;
            }
        }
        #endregion

        #region Reportes
        public List<Movimiento> RptAnalisisCartera(int IdEmpresa)
        {
            try
            {
                DateTimeOffset FechaAhora = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                List<Movimiento> Lista = (from mo in context.Movimientos.Where(x => x.IdEmpresa == IdEmpresa && x.ValorSaldo > 0 && x.TipoDoc.Equals(Constantes.TipoDocFacturaVenta))
                                           join cl in context.Terceros on mo.IdTercero equals cl.IdTercero
                                           join ve in context.Vendedores on cl.IdVendedor equals ve.IdVendedor
                                           join em in context.Empresas on mo.IdEmpresa equals em.IdEmpresa
                                           select new Movimiento()
                                           {
                                               IdMovimiento = mo.IdMovimiento,
                                               TipoDoc = mo.TipoDoc,
                                               NumDoc = mo.NumDoc,
                                               NoDoc = mo.TipoDoc + " " + mo.NumDoc,
                                               IdEmpresa = mo.IdEmpresa,
                                               Empresa = em,
                                               IdVendedor = mo.IdVendedor,
                                               Vendedor = ve,
                                               IdTercero = mo.IdTercero,
                                               Tercero = cl,
                                               FechaDoc = mo.FechaDoc,
                                               FechaVencimiento = mo.FechaVencimiento,
                                               ValorNeto = mo.ValorNeto,
                                               DiasVencidos = (FechaAhora - mo.FechaVencimiento).Days,
                                               ValorSaldo = mo.ValorSaldo,
                                               FechaCreacion = mo.FechaCreacion,
                                               CreadoPor = mo.CreadoPor,
                                               Estado = mo.Estado,
                                           }).ToList();
                return Lista;
            }
            catch(Exception ex)
            {
                errorBusiness.Create("RptAnalisisCartera", ex.Message, null);
                throw;
            }
        }
        #endregion
    }
}
