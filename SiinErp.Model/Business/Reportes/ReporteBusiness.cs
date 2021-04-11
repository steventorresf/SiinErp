using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Reportes;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Entities.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Business.Reportes
{
    public class ReporteBusiness: IReporteBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ReporteBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }


        public List<NumeroFactura> GetNumeroFactura(int IdFactura)
        {
            try
            {
                string CodigoCliente = "";
                string NitCliente = "";
                string NombreCliente = "";
                string DireccionCliente = "";
                string CiudadCliente = "";
                string TelefonoCliente = "";

                Movimiento entityMovimiento = context.Movimientos.Find(IdFactura);
                if(entityMovimiento.IdTercero != null)
                {
                    Tercero entityCliente = context.Terceros.Find(entityMovimiento.IdTercero);
                    Ciudad entityCiudad = context.Ciudades.Find(entityCliente.IdCiudad);
                    CodigoCliente = entityCliente.CodTercero;
                    NitCliente = entityCliente.NitCedula;
                    NombreCliente = entityCliente.NombreTercero;
                    CiudadCliente = entityCiudad.NombreCiudad;
                    TelefonoCliente = entityCliente.Telefono;
                }

                List<NumeroFactura> Listado = (from mo in context.Movimientos.Where(x => x.IdMovimiento == IdFactura)
                                               join md in context.MovimientosDetalles on mo.IdMovimiento equals md.IdMovimiento
                                               join em in context.Empresas on mo.IdEmpresa equals em.IdEmpresa
                                               join ar in context.Articulos on md.IdArticulo equals ar.IdArticulo
                                               join pp in context.TablasDetalles on mo.IdPlazoPago equals pp.IdDetalle into LeftJoinPp
                                               from LJPp in LeftJoinPp.DefaultIfEmpty()
                                               join rd in context.Resolucion on mo.IdResolucion equals rd.IdResolucion into LeftJoinRd
                                               from LJRs in LeftJoinRd.DefaultIfEmpty()
                                               select new NumeroFactura()
                                               {
                                                   RazonSocial = em.RazonSocial,
                                                   NitEmpresa = em.NitEmpresa,
                                                   DireccionEmpresa = em.Direccion,
                                                   TelefonoEmpresa = em.Telefono,
                                                   CiudadEmpresa = em.Ciudad,
                                                   Representante = em.Representante,
                                                   TipoDocumento = mo.TipoDoc,
                                                   NumeroDocumento = mo.NumDoc,
                                                   CodigoCliente = CodigoCliente,
                                                   NitCliente = NitCliente,
                                                   NombreCliente = NombreCliente,
                                                   DireccionCliente = DireccionCliente,
                                                   CiudadCliente = CiudadCliente,
                                                   TelefonoCliente = TelefonoCliente,
                                                   FechaFactura = mo.FechaDoc.ToString("dd/MM/yyyy"),
                                                   PlazoPago = LJPp != null ? LJPp.Descripcion : "",
                                                   FechaVecimiento = mo.FechaVencimiento.ToString("dd/MM/yyyy"),
                                                   DescripcionArticulo = ar.NombreArticulo,
                                                   Cantidad = md.Cantidad,
                                                   PcIva = md.PcIva,
                                                   VrUnitario = md.VrBruto,
                                                   VrNeto = md.VrNeto,
                                                   ValorBruto = mo.ValorBruto,
                                                   ValorDscto = mo.ValorDscto,
                                                   ValorIva = mo.ValorIva,
                                                   ValorNeto = mo.ValorNeto,
                                                   NoResolucion = LJRs != null ? LJRs.NoResolucion : "",
                                                   FechaResolucion = LJRs != null ? LJRs.Fecha.ToString("dddd-MM-dd") : "",
                                                   RangoResolucion = LJRs != null ? LJRs.NumeroInicio + " AL " + LJRs.NumeroFin : "",
                                               }).ToList();
                return Listado;
            }
            catch(Exception ex)
            {
                errorBusiness.Create("GetNumeroFactura", ex, null);
                throw;
            }
        }
    }
}
