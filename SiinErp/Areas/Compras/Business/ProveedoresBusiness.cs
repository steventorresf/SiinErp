using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Compras.Business
{
    public class ProveedoresBusiness
    {
        public List<Proveedores> GetProveedores(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Proveedores> Lista = (from pro in context.Proveedores.Where(x => x.IdEmpresa == IdEmp)
                                           join tip in context.TablasEmpresaDetalles on pro.IdDetTipoProv equals tip.IdDetalle
                                           join pla in context.PlazosPagos on pro.IdPlazoPago equals pla.IdPlazoPago
                                           join ciu in context.Ciudades on pro.IdCiudad equals ciu.IdCiudad
                                           join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                           select new Proveedores()
                                           {
                                               IdProveedor = pro.IdProveedor,
                                               IdEmpresa = pro.IdEmpresa,
                                               NitCedula = pro.NitCedula,
                                               DgVerificacion = pro.DgVerificacion,
                                               NombreProveedor = pro.NombreProveedor,
                                               IdDetTipoProv = pro.IdDetTipoProv,
                                               RepresentanteLegal = pro.RepresentanteLegal,
                                               Direccion = pro.Direccion,
                                               EMail = pro.EMail,
                                               IdCiudad = pro.IdCiudad,
                                               Telefono = pro.Telefono,
                                               IdCuentaContable = pro.IdCuentaContable,
                                               IdPlazoPago = pro.IdPlazoPago,
                                               IdUsuario = pro.IdUsuario,
                                               FechaCreacion = pro.FechaCreacion,
                                               FechaUltCompra = pro.FechaUltCompra,
                                               FechaUltPago = pro.FechaUltPago,
                                               Estado = pro.Estado,
                                               NombreTipoProv = tip.Descripcion,
                                               PlazoPago = pla,
                                               NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                               IdDepartamento = dep.IdDepartamento,
                                           }).OrderBy(x => x.NombreProveedor).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetProveedores", ex.Message, null);
                throw;
            }
        }

        public void Create(Proveedores entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Proveedores.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateProveedor", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdProveedor, Proveedores entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Proveedores ob = context.Proveedores.Find(IdProveedor);
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.NombreProveedor = entity.NombreProveedor;
                ob.IdDetTipoProv = entity.IdDetTipoProv;
                ob.RepresentanteLegal = entity.RepresentanteLegal;
                ob.Direccion = entity.Direccion;
                ob.EMail = entity.EMail;
                ob.IdCiudad = entity.IdCiudad;
                ob.Telefono = entity.Telefono;
                ob.IdCuentaContable = entity.IdCuentaContable;
                ob.IdPlazoPago = entity.IdPlazoPago;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateProveedor", ex.Message, null);
                throw;
            }
        }
    }
}
