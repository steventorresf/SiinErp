using SiinErp.Areas.Compras.Abstract;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Business
{
    public class OrdenBusiness : IOrdenBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public OrdenBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }

        public List<Orden> GetOrdenes(int IdEmp, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Orden> Lista = (from ord in context.Ordenes.Where(x => x.IdEmpresa == IdEmp && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin)
                                       join pro in context.Terceros on ord.IdProveedor equals pro.IdTercero
                                       join ppa in context.PlazosPagos on ord.IdPlazoPago equals ppa.IdPlazoPago
                                       select new Orden()
                                       {
                                           IdOrden = ord.IdOrden,
                                           TipoDoc = ord.TipoDoc,
                                           NumDoc = ord.NumDoc,
                                           IdProveedor = ord.IdProveedor,
                                           FechaCreacion = ord.FechaCreacion,
                                           FechaDoc = ord.FechaDoc,
                                           ValorBruto = ord.ValorBruto,
                                           ValorDscto = ord.ValorDscto,
                                           ValorIva = ord.ValorIva,
                                           ValorNeto = ord.ValorNeto,
                                           Proveedor = pro,
                                           Estado = ord.Estado,
                                           DireccionDesp = ord.DireccionDesp,
                                           IdPlazoPago = ord.IdPlazoPago,
                                           IdEmpresa = ord.IdEmpresa,
                                           Periodo = ord.Periodo,
                                           IdDetAlmacen = ord.IdDetAlmacen,
                                           IdDetCenCosto = ord.IdDetCenCosto,
                                           Comentarios = ord.Comentarios,
                                           PlazoPago = ppa,
                                       }).OrderByDescending(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetOrdenCompra", ex.Message, null);
                throw;
            }
        }

        public List<Orden> GetOrdenesPendientes(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Orden> Lista = (from ord in context.Ordenes.Where(x => x.IdEmpresa == IdEmp && x.Estado.Equals(Constantes.EstadoPendiente))
                                       join pro in context.Terceros on ord.IdProveedor equals pro.IdTercero
                                       join ppa in context.PlazosPagos on ord.IdPlazoPago equals ppa.IdPlazoPago
                                       select new Orden()
                                       {
                                           IdOrden = ord.IdOrden,
                                           TipoDoc = ord.TipoDoc,
                                           NumDoc = ord.NumDoc,
                                           IdProveedor = ord.IdProveedor,
                                           FechaCreacion = ord.FechaCreacion,
                                           FechaDoc = ord.FechaDoc,
                                           ValorBruto = ord.ValorBruto,
                                           ValorDscto = ord.ValorDscto,
                                           ValorIva = ord.ValorIva,
                                           ValorNeto = ord.ValorNeto,
                                           Proveedor = pro,
                                           Estado = ord.Estado,
                                           DireccionDesp = ord.DireccionDesp,
                                           IdPlazoPago = ord.IdPlazoPago,
                                           IdEmpresa = ord.IdEmpresa,
                                           Periodo = ord.Periodo,
                                           IdDetAlmacen = ord.IdDetAlmacen,
                                           IdDetCenCosto = ord.IdDetCenCosto,
                                           Comentarios = ord.Comentarios,
                                           PlazoPago = ppa,
                                       }).OrderByDescending(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetOrdenCompraPendientes", ex.Message, null);
                throw;
            }
        }

        public void Create(Orden entity)
        {
            try
            {
                List<OrdenDetalle> listDet = entity.ListDetalle;

                SiinErpContext context = new SiinErpContext();
                TipoDocumento tipoDocumento = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals("OC") && x.IdEmpresa == entity.IdEmpresa);
                tipoDocumento.NumDoc++;
                context.SaveChanges();

                entity.TipoDoc = tipoDocumento.TipoDoc;
                entity.NumDoc = tipoDocumento.NumDoc;
                entity.Periodo = DateTimeOffset.Now.ToString("yyyyMM");
                entity.FechaCreacion = DateTimeOffset.Now;
                context.Ordenes.Add(entity);
                context.SaveChanges();

                Orden orden = context.Ordenes.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                foreach (OrdenDetalle det in listDet)
                {
                    det.IdDetalleOrden = 0;
                    det.IdOrden = orden.IdOrden;
                }
                context.OrdenesDetalles.AddRange(listDet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateOrdenCompra", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdOrd, Orden entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Orden obOrd = context.Ordenes.Find(IdOrd);
                obOrd.IdProveedor = entity.IdProveedor;
                obOrd.IdDetAlmacen = entity.IdDetAlmacen;
                obOrd.DireccionDesp = entity.DireccionDesp;
                obOrd.IdDetCenCosto = entity.IdDetCenCosto;
                obOrd.FechaDoc = entity.FechaDoc;
                obOrd.IdPlazoPago = entity.IdPlazoPago;
                obOrd.Comentarios = entity.Comentarios;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateOrdenCompra", ex.Message, null);
                throw;
            }
        }


    }
}
