using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Ventas
{
    public class VendedorBusiness : IVendedorBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public VendedorBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Vendedor> GetVendedores(int IdEmp)
        {
            try
            {
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
                                            CreadoPor = ven.CreadoPor,
                                            EstadoFila = ven.EstadoFila,
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
                List<Vendedor> Lista = context.Vendedores.Where(x => x.IdEmpresa == IdEmp && x.EstadoFila.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreVendedor).ToList();
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
                Vendedor ob = context.Vendedores.Find(IdVendedor);
                ob.NombreVendedor = entity.NombreVendedor;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.IdDetZona = entity.IdDetZona;
                ob.EstadoFila = entity.EstadoFila;
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