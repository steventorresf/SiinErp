using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TerceroBusiness : ITerceroBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public TerceroBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Tercero> GetTerceros(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = (from ter in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Otros))
                                        join tip in context.TablasDetalles on ter.IdDetTipoPersona equals tip.IdDetalle
                                        join ciu in context.Ciudades on ter.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        select new Tercero()
                                        {
                                            IdTercero = ter.IdTercero,
                                            IdEmpresa = ter.IdEmpresa,
                                            TipoTercero = ter.TipoTercero,
                                            NitCedula = ter.NitCedula,
                                            DgVerificacion = ter.DgVerificacion,
                                            IdDetTipoPersona = ter.IdDetTipoPersona,
                                            NombreTipoPersona = tip.Descripcion,
                                            NombreTercero = ter.NombreTercero,
                                            IdCiudad = ter.IdCiudad,
                                            Direccion = ter.Direccion,
                                            Telefono = ter.Telefono,
                                            FechaCreacion = ter.FechaCreacion,
                                            CreadoPor = ter.CreadoPor,
                                            Estado = ter.Estado,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTerceros", ex.Message, null);
                throw;
            }
        }

        public List<Tercero> GetTercerosActivos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.Estado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetTercerosActivos", ex.Message, null);
                throw;
            }
        }

        public void Create(Tercero entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.Terceros.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateTercero", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTercero, Tercero entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Tercero ob = context.Terceros.Find(IdTercero);
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.IdDetTipoPersona = entity.IdDetTipoPersona;
                ob.NombreTercero = entity.NombreTercero;
                ob.IdCiudad = entity.IdCiudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateTercero", ex.Message, null);
                throw;
            }
        }

        #region Proveedores
        public List<Tercero> GetProveedores(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = (from pro in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Proveedor))
                                        join tip in context.TablasDetalles on pro.IdDetTipoPersona equals tip.IdDetalle
                                        join pla in context.PlazosPagos on pro.IdPlazoPago equals pla.IdPlazoPago
                                        join ciu in context.Ciudades on pro.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        select new Tercero()
                                        {
                                            IdTercero = pro.IdTercero,
                                            IdEmpresa = pro.IdEmpresa,
                                            TipoTercero = pro.TipoTercero,
                                            NitCedula = pro.NitCedula,
                                            DgVerificacion = pro.DgVerificacion,
                                            NombreTercero = pro.NombreTercero,
                                            IdDetTipoPersona = pro.IdDetTipoPersona,
                                            Direccion = pro.Direccion,
                                            EMail = pro.EMail,
                                            IdCiudad = pro.IdCiudad,
                                            Telefono = pro.Telefono,
                                            IdCuentaContable = pro.IdCuentaContable,
                                            IdPlazoPago = pro.IdPlazoPago,
                                            CreadoPor = pro.CreadoPor,
                                            FechaCreacion = pro.FechaCreacion,
                                            Estado = pro.Estado,
                                            NombreTipoPersona = tip.Descripcion,
                                            PlazoPago = pla,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetProveedores", ex.Message, null);
                throw;
            }
        }

        public List<Tercero> GetProveedoresActivos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = (from pro in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Proveedor) && x.Estado.Equals(Constantes.EstadoActivo))
                                        join tip in context.TablasDetalles on pro.IdDetTipoPersona equals tip.IdDetalle
                                        join pla in context.PlazosPagos on pro.IdPlazoPago equals pla.IdPlazoPago
                                        join ciu in context.Ciudades on pro.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        select new Tercero()
                                        {
                                            IdTercero = pro.IdTercero,
                                            IdEmpresa = pro.IdEmpresa,
                                            TipoTercero = pro.TipoTercero,
                                            NitCedula = pro.NitCedula,
                                            DgVerificacion = pro.DgVerificacion,
                                            NombreTercero = pro.NombreTercero,
                                            IdDetTipoPersona = pro.IdDetTipoPersona,
                                            Direccion = pro.Direccion,
                                            EMail = pro.EMail,
                                            IdCiudad = pro.IdCiudad,
                                            Telefono = pro.Telefono,
                                            IdCuentaContable = pro.IdCuentaContable,
                                            IdPlazoPago = pro.IdPlazoPago,
                                            CreadoPor = pro.CreadoPor,
                                            FechaCreacion = pro.FechaCreacion,
                                            Estado = pro.Estado,
                                            NombreTipoPersona = tip.Descripcion,
                                            PlazoPago = pla,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetProveedoresActivos", ex.Message, null);
                throw;
            }
        }

        public void UpdateProveedor(int IdProveedor, Tercero entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Tercero ob = context.Terceros.Find(IdProveedor);
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.NombreTercero = entity.NombreTercero;
                ob.IdDetTipoPersona = entity.IdDetTipoPersona;
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
                errorBusiness.Create("UpdateProveedor", ex.Message, null);
                throw;
            }
        }
        #endregion

        #region Clientes
        public List<Tercero> GetClientes(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = (from cli in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Cliente))
                                        join tip in context.TablasDetalles on cli.IdDetTipoPersona equals tip.IdDetalle
                                        join ciu in context.Ciudades on cli.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        join zon in context.TablasDetalles on cli.IdDetZona equals zon.IdDetalle
                                        join pla in context.PlazosPagos on cli.IdPlazoPago equals pla.IdPlazoPago
                                        select new Tercero()
                                        {
                                            IdTercero = cli.IdTercero,
                                            TipoTercero = cli.TipoTercero,
                                            IdEmpresa = cli.IdEmpresa,
                                            NitCedula = cli.NitCedula,
                                            DgVerificacion = cli.DgVerificacion,
                                            IdDetTipoPersona = cli.IdDetTipoPersona,
                                            NombreTercero = cli.NombreTercero,
                                            Direccion = cli.Direccion,
                                            EMail = cli.EMail,
                                            IdCiudad = cli.IdCiudad,
                                            Telefono = cli.Telefono,
                                            IdDetZona = cli.IdDetZona,
                                            IdVendedor = cli.IdVendedor,
                                            IdCuentaContable = cli.IdCuentaContable,
                                            IdPlazoPago = cli.IdPlazoPago,
                                            LimiteCredito = cli.LimiteCredito,
                                            IdPadre = cli.IdPadre,
                                            IdListaPrecio = cli.IdListaPrecio,
                                            Iva = cli.Iva,
                                            FechaCreacion = cli.FechaCreacion,
                                            CreadoPor = cli.CreadoPor,
                                            Estado = cli.Estado,
                                            NombreTipoPersona = tip.Descripcion,
                                            PlazoPago = pla,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClientes", ex.Message, null);
                throw;
            }
        }

        public Tercero GetClienteByIden(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                string NitCedula = data["nitCedula"].ToObject<string>();

                SiinErpContext context = new SiinErpContext();
                Tercero entity = (from cli in context.Terceros.Where(x => x.NitCedula.Equals(NitCedula) && x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Cliente))
                                   join tip in context.TablasDetalles on cli.IdDetTipoPersona equals tip.IdDetalle
                                   join ciu in context.Ciudades on cli.IdCiudad equals ciu.IdCiudad
                                   join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                   join zon in context.TablasDetalles on cli.IdDetZona equals zon.IdDetalle
                                   join pla in context.PlazosPagos on cli.IdPlazoPago equals pla.IdPlazoPago
                                   join lip in context.ListaPrecios on cli.IdListaPrecio equals lip.IdListaPrecio
                                   select new Tercero()
                                   {
                                       IdTercero = cli.IdTercero,
                                       TipoTercero = cli.TipoTercero,
                                       IdEmpresa = cli.IdEmpresa,
                                       NitCedula = cli.NitCedula,
                                       DgVerificacion = cli.DgVerificacion,
                                       IdDetTipoPersona = cli.IdDetTipoPersona,
                                       NombreTercero = cli.NombreTercero,
                                       Direccion = cli.Direccion,
                                       EMail = cli.EMail,
                                       IdCiudad = cli.IdCiudad,
                                       Telefono = cli.Telefono,
                                       IdDetZona = cli.IdDetZona,
                                       IdVendedor = cli.IdVendedor,
                                       IdCuentaContable = cli.IdCuentaContable,
                                       IdPlazoPago = cli.IdPlazoPago,
                                       LimiteCredito = cli.LimiteCredito,
                                       IdPadre = cli.IdPadre,
                                       IdListaPrecio = cli.IdListaPrecio,
                                       Iva = cli.Iva,
                                       FechaCreacion = cli.FechaCreacion,
                                       CreadoPor = cli.CreadoPor,
                                       Estado = cli.Estado,
                                       NombreTipoPersona = tip.Descripcion,
                                       PlazoPago = pla,
                                       ListaPrecios = lip,
                                       NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                       IdDepartamento = dep.IdDepartamento,
                                   }).FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClientes", ex.Message, null);
                throw;
            }
        }

        public List<Tercero> GetClientesActivos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Tercero> Lista = (from cli in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Cliente) && x.Estado.Equals(Constantes.EstadoActivo))
                                        join tip in context.TablasDetalles on cli.IdDetTipoPersona equals tip.IdDetalle
                                        join ciu in context.Ciudades on cli.IdCiudad equals ciu.IdCiudad
                                        join dep in context.Departamentos on ciu.IdDepartamento equals dep.IdDepartamento
                                        join zon in context.TablasDetalles on cli.IdDetZona equals zon.IdDetalle
                                        join pla in context.PlazosPagos on cli.IdPlazoPago equals pla.IdPlazoPago
                                        select new Tercero()
                                        {
                                            IdTercero = cli.IdTercero,
                                            TipoTercero = cli.TipoTercero,
                                            IdEmpresa = cli.IdEmpresa,
                                            NitCedula = cli.NitCedula,
                                            DgVerificacion = cli.DgVerificacion,
                                            IdDetTipoPersona = cli.IdDetTipoPersona,
                                            NombreTercero = cli.NombreTercero,
                                            Direccion = cli.Direccion,
                                            EMail = cli.EMail,
                                            IdCiudad = cli.IdCiudad,
                                            Telefono = cli.Telefono,
                                            IdDetZona = cli.IdDetZona,
                                            IdVendedor = cli.IdVendedor,
                                            IdCuentaContable = cli.IdCuentaContable,
                                            IdPlazoPago = cli.IdPlazoPago,
                                            LimiteCredito = cli.LimiteCredito,
                                            IdPadre = cli.IdPadre,
                                            IdListaPrecio = cli.IdListaPrecio,
                                            Iva = cli.Iva,
                                            FechaCreacion = cli.FechaCreacion,
                                            CreadoPor = cli.CreadoPor,
                                            Estado = cli.Estado,
                                            NombreTipoPersona = tip.Descripcion,
                                            PlazoPago = pla,
                                            NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                            IdDepartamento = dep.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClientesActivos", ex.Message, null);
                throw;
            }
        }

        public void UpdateCliente(int IdCliente, Tercero entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Tercero obCli = context.Terceros.Find(IdCliente);
                obCli.NitCedula = entity.NitCedula;
                obCli.DgVerificacion = entity.DgVerificacion;
                obCli.NombreTercero = entity.NombreTercero;
                obCli.IdDetTipoPersona = entity.IdDetTipoPersona;
                obCli.Direccion = entity.Direccion;
                obCli.EMail = entity.EMail;
                obCli.IdCiudad = entity.IdCiudad;
                obCli.Telefono = entity.Telefono;
                obCli.IdDetZona = entity.IdDetZona;
                obCli.IdVendedor = entity.IdVendedor;
                obCli.IdCuentaContable = entity.IdCuentaContable;
                obCli.IdPlazoPago = entity.IdPlazoPago;
                obCli.LimiteCredito = entity.LimiteCredito;
                obCli.IdPadre = entity.IdPadre;
                obCli.IdListaPrecio = entity.IdListaPrecio;
                obCli.Iva = entity.Iva;
                obCli.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateCliente", ex.Message, null);
                throw;
            }
        }
        #endregion
    }
}
