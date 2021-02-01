using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Abstract;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class VendedorBusiness : IVendedorBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public VendedorBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Vendedor> GetVendedores(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Vendedor> Lista = (from ven in context.Vendedores.Where(x => x.IdEmpresa == IdEmp)
                                          join zon in context.TablasDetalles on ven.IdDetZona equals zon.IdDetalle
                                          select new Vendedor()
                                          {
                                              IdVendedor = ven.IdVendedor,
                                              IdEmpresa = ven.IdEmpresa,
                                              NombreVendedor = ven.NombreVendedor,
                                              Direccion = ven.Direccion,
                                              Telefono = ven.Telefono,
                                              IdDetZona = ven.IdDetZona,
                                              FechaCreacion = ven.FechaCreacion,
                                              IdUsuario = ven.IdUsuario,
                                              Estado = ven.Estado,
                                              NombreZona = zon.Descripcion,
                                          }).OrderBy(x => x.NombreVendedor).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetVendedores", ex.Message, null);
                throw;
            }
        }

        public List<Vendedor> GetVendedoresAct(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Vendedor> Lista = context.Vendedores.Where(x => x.IdEmpresa == IdEmp && x.Estado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreVendedor).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetVendedoresAct", ex.Message, null);
                throw;
            }
        }

        public void Create(Vendedor entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Vendedores.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateVendedor", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdVendedor, Vendedor entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Vendedor ob = context.Vendedores.Find(IdVendedor);
                ob.NombreVendedor = entity.NombreVendedor;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.IdDetZona = entity.IdDetZona;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateVendedor", ex.Message, null);
                throw;
            }
        }
    }
}
