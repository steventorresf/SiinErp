using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class ClientesBusiness
    {
        public List<Clientes> GetClientes(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Clientes> Lista = (from cli in context.Clientes.Where(x => x.IdEmpresa == IdEmp)
                                        join tip in context.TablasDetalles on cli.IdDetTipoCliente equals tip.IdDetalle
                                        join ciu in context.Ciudades on cli.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        join zon in context.TablasDetalles on cli.IdDetZona equals zon.IdDetalle
                                        join pla in context.PlazosPagos on cli.IdPlazoPago equals pla.IdPlazoPago
                                        select new Clientes()
                                        {
                                            IdCliente = cli.IdCliente,
                                            CodCliente = cli.CodCliente,
                                            IdEmpresa = cli.IdEmpresa,
                                            NitCedula = cli.NitCedula,
                                            DgVerificacion = cli.DgVerificacion,
                                            IdDetTipoCliente = cli.IdDetTipoCliente,
                                            NombreCliente = cli.NombreCliente,
                                            NombreComercial = cli.NombreComercial,
                                            RepresentanteLegal = cli.RepresentanteLegal,
                                            Direccion = cli.Direccion,
                                            Correo = cli.Correo,
                                            IdCiudad = cli.IdCiudad,
                                            Telefono = cli.Telefono,
                                            IdDetZona = cli.IdDetZona,
                                            IdVendedor = cli.IdVendedor,
                                            IdCuentaContable = cli.IdCuentaContable,
                                            Credito = cli.Credito,
                                            Retencion = cli.Retencion,
                                            IdPlazoPago = cli.IdPlazoPago,
                                            LimiteCredito = cli.LimiteCredito,
                                            IdPadre = cli.IdPadre,
                                            IdListaPrecio = cli.IdListaPrecio,
                                            Iva = cli.Iva,
                                            EsCadena = cli.EsCadena,
                                            PuntosAcumulados = cli.PuntosAcumulados,
                                            FechaUltCompra = cli.FechaUltCompra,
                                            FechaUltPago = cli.FechaUltPago,
                                            BaseRetencion = cli.BaseRetencion,
                                            FechaCreacion = cli.FechaCreacion,
                                            IdUsuario = cli.IdUsuario,
                                            Estado = cli.Estado,
                                            NombreTipoCliente = tip.Descripcion,
                                            PlazoPago = pla,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreCliente).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetClientes", ex.Message, null);
                throw;
            }
        }

        public void Create(Clientes entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Clientes.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateCliente", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdCliente, Clientes entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Clientes ob = context.Clientes.Find(IdCliente);
                ob.CodCliente = entity.CodCliente;
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.NombreCliente = entity.NombreCliente;
                ob.IdDetTipoCliente = entity.IdDetTipoCliente;
                ob.NombreComercial = entity.NombreComercial;
                ob.RepresentanteLegal = entity.RepresentanteLegal;
                ob.Direccion = entity.Direccion;
                ob.Correo = entity.Correo;
                ob.IdCiudad = entity.IdCiudad;
                ob.Telefono = entity.Telefono;
                ob.IdDetZona = entity.IdDetZona;
                ob.IdVendedor = entity.IdVendedor;
                ob.IdCuentaContable = entity.IdCuentaContable;
                ob.Credito = entity.Credito;
                ob.Retencion = entity.Retencion;
                ob.IdPlazoPago = entity.IdPlazoPago;
                ob.LimiteCredito = entity.LimiteCredito;
                ob.IdPadre = entity.IdPadre;
                ob.IdListaPrecio = entity.IdListaPrecio;
                ob.Iva = entity.Iva;
                ob.EsCadena = entity.EsCadena;
                ob.PuntosAcumulados = entity.PuntosAcumulados;
                ob.BaseRetencion = entity.BaseRetencion;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateCliente", ex.Message, null);
                throw;
            }
        }
    }
}
