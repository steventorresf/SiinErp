using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class TerceroBusiness : ITerceroBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public TerceroBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Tercero> GetTerceros(int IdEmpresa)
        {
            try
            {
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
                                           NombreBusqueda = ter.NombreBusqueda,
                                           IdCiudad = ter.IdCiudad,
                                           Direccion = ter.Direccion,
                                           Telefono = ter.Telefono,
                                           FechaCreacion = ter.FechaCreacion,
                                           CreadoPor = ter.CreadoPor,
                                           EstadoFila = ter.EstadoFila,
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
                List<Tercero> Lista = context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.EstadoFila.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreTercero).ToList();
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
                using(var tran = context.Database.BeginTransaction())
                {
                    if (entity.TipoTercero.Equals(Constantes.Cliente))
                    {
                        Secuencia entitySec = context.Secuencia.Find(entity.TipoTercero);
                        entitySec.NoSecuencia++;
                        context.SaveChanges();

                        entity.CodTercero = Seguridad.GetPrefijoSecuencia(entitySec.Prefijo, entitySec.NoSecuencia, entitySec.Longitud);
                    }

                    entity.NombreBusqueda = entity.CodTercero + " - " + entity.NitCedula + " - " + entity.NombreTercero;
                    entity.FechaCreacion = DateTimeOffset.Now;
                    entity.FechaModificado = DateTimeOffset.Now;
                    context.Terceros.Add(entity);
                    context.SaveChanges();

                    tran.Commit();
                }
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
                Tercero ob = context.Terceros.Find(IdTercero);
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.IdDetTipoPersona = entity.IdDetTipoPersona;
                ob.NombreTercero = entity.NombreTercero;
                ob.IdCiudad = entity.IdCiudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.EstadoFila = entity.EstadoFila;
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
                                           NombreBusqueda = pro.NombreBusqueda,
                                           IdDetTipoPersona = pro.IdDetTipoPersona,
                                           Direccion = pro.Direccion,
                                           EMail = pro.EMail,
                                           IdCiudad = pro.IdCiudad,
                                           Telefono = pro.Telefono,
                                           IdCuentaContable = pro.IdCuentaContable,
                                           IdPlazoPago = pro.IdPlazoPago,
                                           CreadoPor = pro.CreadoPor,
                                           FechaCreacion = pro.FechaCreacion,
                                           EstadoFila = pro.EstadoFila,
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
                List<Tercero> Lista = (from pro in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Proveedor) && x.EstadoFila.Equals(Constantes.EstadoActivo))
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
                                           NombreBusqueda = pro.NombreBusqueda,
                                           IdDetTipoPersona = pro.IdDetTipoPersona,
                                           Direccion = pro.Direccion,
                                           EMail = pro.EMail,
                                           IdCiudad = pro.IdCiudad,
                                           Telefono = pro.Telefono,
                                           IdCuentaContable = pro.IdCuentaContable,
                                           IdPlazoPago = pro.IdPlazoPago,
                                           CreadoPor = pro.CreadoPor,
                                           FechaCreacion = pro.FechaCreacion,
                                           EstadoFila = pro.EstadoFila,
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
                ob.EstadoFila = entity.EstadoFila;
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
                                           CodTercero = cli.CodTercero,
                                           NitCedula = cli.NitCedula,
                                           DgVerificacion = cli.DgVerificacion,
                                           IdDetTipoPersona = cli.IdDetTipoPersona,
                                           NombreTercero = cli.NombreTercero,
                                           NombreBusqueda = cli.NombreBusqueda,
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
                                           EstadoFila = cli.EstadoFila,
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

        public List<Tercero> GetClienteListById(int IdTercero)
        {
            try
            {
                List<Tercero> Lista = (from cli in context.Terceros.Where(x => x.IdTercero == IdTercero)
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
                                           CodTercero = cli.CodTercero,
                                           NitCedula = cli.NitCedula,
                                           DgVerificacion = cli.DgVerificacion,
                                           IdDetTipoPersona = cli.IdDetTipoPersona,
                                           NombreTercero = cli.NombreTercero,
                                           NombreBusqueda = cli.NombreBusqueda,
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
                                           EstadoFila = cli.EstadoFila,
                                           NombreTipoPersona = tip.Descripcion,
                                           PlazoPago = pla,
                                           ListaPrecios = lip,
                                           NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                           IdDepartamento = dep.IdDepartamento,
                                       }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClienteListById", ex.Message, null);
                throw;
            }
        }

        public Tercero GetClienteByIden(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                string NitCedula = data["nitCedula"].ToObject<string>();
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
                                      CodTercero = cli.CodTercero,
                                      NitCedula = cli.NitCedula,
                                      DgVerificacion = cli.DgVerificacion,
                                      IdDetTipoPersona = cli.IdDetTipoPersona,
                                      NombreTercero = cli.NombreTercero,
                                      NombreBusqueda = cli.NombreBusqueda,
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
                                      EstadoFila = cli.EstadoFila,
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

        public List<Tercero> GetClientesByPrefix(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                string Prefix = data["prefix"].ToObject<string>();

                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tercero> Lista = (from cli in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Cliente) && x.NombreBusqueda.Contains(ListPrefix[0]))
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
                                           CodTercero = cli.CodTercero,
                                           NitCedula = cli.NitCedula,
                                           DgVerificacion = cli.DgVerificacion,
                                           IdDetTipoPersona = cli.IdDetTipoPersona,
                                           NombreTercero = cli.NombreTercero,
                                           NombreBusqueda = cli.NombreBusqueda,
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
                                           EstadoFila = cli.EstadoFila,
                                           NombreTipoPersona = tip.Descripcion,
                                           PlazoPago = pla,
                                           ListaPrecios = lip,
                                           NombreCiudad = ciu.NombreCiudad + " - " + dep.NombreDepartamento,
                                           IdDepartamento = dep.IdDepartamento,
                                       }).ToList();

                for (int i = 1; i < ListPrefix.Length; i++)
                {
                    Lista = Lista.Where(x => x.NombreBusqueda.Contains(ListPrefix[i])).ToList();
                }

                return Lista.OrderBy(x => x.NombreBusqueda).ToList();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetClientesByPrefix", ex.Message, null);
                throw;
            }
        }

        public List<Tercero> GetClientesActivos(int IdEmpresa)
        {
            try
            {
                List<Tercero> Lista = (from cli in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.TipoTercero.Equals(Constantes.Cliente) && x.EstadoFila.Equals(Constantes.EstadoActivo))
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
                                           CodTercero = cli.CodTercero,
                                           NitCedula = cli.NitCedula,
                                           DgVerificacion = cli.DgVerificacion,
                                           IdDetTipoPersona = cli.IdDetTipoPersona,
                                           NombreTercero = cli.NombreTercero,
                                           NombreBusqueda = cli.NombreBusqueda,
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
                                           EstadoFila = cli.EstadoFila,
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
                Tercero obCli = context.Terceros.Find(IdCliente);
                obCli.NitCedula = entity.NitCedula;
                obCli.DgVerificacion = entity.DgVerificacion;
                obCli.NombreTercero = entity.NombreTercero;
                obCli.NombreBusqueda = entity.CodTercero + " - " + entity.NitCedula + " - " + entity.NombreTercero;
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
                obCli.EstadoFila = entity.EstadoFila;
                obCli.ModificadoPor = entity.ModificadoPor;
                obCli.FechaModificado = DateTimeOffset.Now;
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