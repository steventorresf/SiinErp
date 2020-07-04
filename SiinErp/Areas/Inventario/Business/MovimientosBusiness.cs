using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Inventario.Entities;
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
        public void CreateByEntradaCompra(string numFactura, Ordenes entityOrd, Movimientos entityMov, List<MovimientosDetalle> listaDetalleMov)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                context.MovimientosDetalles.AddRange(listaDetalleMov);
                context.SaveChanges();

                Facturas factura = new Facturas();
                factura.TipoDoc = entityMov.TipoDoc;
                factura.NumDoc = entityMov.NumDoc;
                factura.Comentario = entityMov.Comentario;
                factura.FechaDoc = entityMov.FechaDoc;
                factura.Periodo = entityMov.Periodo;
                factura.IdDetAlmacen = entityMov.IdDetAlmacen;
                factura.IdDetCenCosto = entityMov.IdDetCenCosto;
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

                int[] idsArticulos = listaDetalleMov.Select(x => x.IdArticulo).ToArray();

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

                List<Articulos> listArticulos = context.Articulos.Where(x => idsArticulos.Contains(x.IdArticulo)).ToList();
                foreach(Articulos art in listArticulos)
                {
                    MovimientosDetalle movdet = listaDetalleMov.FirstOrDefault(x => x.IdArticulo == art.IdArticulo);
                    art.VrCosto = movdet.VrCosto;
                    art.FechaUEntrada = entityMov.FechaDoc;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateMovimientoByEntradaCompra", ex.Message, null);
                throw;
            }
        }
    }
}
