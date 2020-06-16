using SiinErp.Areas.General.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class VendedoresBusiness
    {
        public List<Vendedores> GetVendedores(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Vendedores> Lista = (from ven in context.Vendedores.Where(x => x.IdEmpresa == IdEmp)
                                          join zon in context.TablasDetalles on ven.IdDetZona equals zon.IdDetalle
                                          select new Vendedores()
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
                ErroresBusiness.Create("GetVendedores", ex.Message, null);
                throw;
            }
        }

        public void Create(Vendedores entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Vendedores.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateVendedor", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdVendedor, Vendedores entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Vendedores ob = context.Vendedores.Find(IdVendedor);
                ob.NombreVendedor = entity.NombreVendedor;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.IdDetZona = entity.IdDetZona;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateVendedor", ex.Message, null);
                throw;
            }
        }
    }
}
