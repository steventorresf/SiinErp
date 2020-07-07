using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Business
{
    public class OrdenesBusiness
    {
        public List<Ordenes> GetOrdenes(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Ordenes> Lista = (from ord in context.Ordenes.Where(x => x.IdEmpresa == IdEmp)
                                       join pro in context.Proveedores on ord.IdProveedor equals pro.IdProveedor
                                       join ppa in context.PlazosPagos on ord.IdPlazoPago equals ppa.IdPlazoPago
                                       select new Ordenes()
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
                ErroresBusiness.Create("GetOrdenCompra", ex.Message, null);
                throw;
            }
        }

        public void Create(Ordenes entity)
        {
            try
            {
                List<OrdenesDetalle> listDet = entity.ListDetalle;

                SiinErpContext context = new SiinErpContext();
                TiposDocumento tipoDocumento = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals("OC") && x.IdEmpresa == entity.IdEmpresa);

                entity.TipoDoc = tipoDocumento.TipoDoc;
                entity.NumDoc = tipoDocumento.NumDoc;
                entity.Periodo = DateTimeOffset.Now.ToString("yyyyMM");
                entity.FechaCreacion = DateTimeOffset.Now;
                tipoDocumento.NumDoc++;
                context.Ordenes.Add(entity);
                context.SaveChanges();

                Ordenes orden = context.Ordenes.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                foreach (OrdenesDetalle det in listDet)
                {
                    det.IdDetalleOrden = 0;
                    det.IdOrden = orden.IdOrden;
                }
                context.OrdenesDetalles.AddRange(listDet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateOrdenCompra", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdOrd, Ordenes entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Ordenes obOrd = context.Ordenes.Find(IdOrd);
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
                ErroresBusiness.Create("UpdateOrdenCompra", ex.Message, null);
                throw;
            }
        }


    }
}
