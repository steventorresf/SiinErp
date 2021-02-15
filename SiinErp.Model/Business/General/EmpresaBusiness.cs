using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class EmpresaBusiness : IEmpresaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public EmpresaBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Empresa> GetEmpresas()
        {
            try
            {
                List<Empresa> Lista = (from em in context.Empresas
                                       join ci in context.Ciudades on em.IdCiudad equals ci.IdCiudad
                                       join de in context.Departamentos on ci.IdDepartamento equals de.IdDepartamento
                                       join re in context.TablasDetalles on em.IdDetRegimen equals re.IdDetalle
                                       select new Empresa()
                                       {
                                           IdEmpresa = em.IdEmpresa,
                                           NitEmpresa = em.NitEmpresa,
                                           RazonSocial = em.RazonSocial,
                                           IdCiudad = em.IdCiudad,
                                           Direccion = em.Direccion,
                                           Telefono = em.Telefono,
                                           CodEan = em.CodEan,
                                           Representante = em.Representante,
                                           IdDetRegimen = em.IdDetRegimen,
                                           IdDepartamento = de.IdDepartamento,
                                           NombreCiudad = ci.NombreCiudad + " - " + de.NombreDepartamento,
                                           NombreRegimen = re.Descripcion,
                                       }).OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }

        public List<Empresa> GetEmpresasAct()
        {
            try
            {
                List<Empresa> Lista = (from em in context.Empresas
                                       join ci in context.Ciudades on em.IdCiudad equals ci.IdCiudad
                                       join de in context.Departamentos on ci.IdDepartamento equals de.IdDepartamento
                                       select new Empresa()
                                       {
                                           IdEmpresa = em.IdEmpresa,
                                           NitEmpresa = em.NitEmpresa,
                                           RazonSocial = em.RazonSocial,
                                           IdCiudad = em.IdCiudad,
                                           Direccion = em.Direccion,
                                           Telefono = em.Telefono,
                                           CodEan = em.CodEan,
                                           Representante = em.Representante,
                                           IdDetRegimen = em.IdDetRegimen,
                                           IdDepartamento = de.IdDepartamento,
                                           NombreCiudad = ci.NombreCiudad + " - " + de.NombreDepartamento,
                                       }).OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }

        public void Create(Empresa entity)
        {
            try
            {
                context.Empresas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateEmpresa", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdEmpresa, Empresa entity)
        {
            try
            {
                Empresa ob = context.Empresas.Find(IdEmpresa);
                ob.RazonSocial = entity.RazonSocial;
                ob.NitEmpresa = entity.NitEmpresa;
                ob.IdCiudad = entity.IdCiudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.CodEan = entity.CodEan;
                ob.Representante = entity.Representante;
                ob.IdDetRegimen = entity.IdDetRegimen;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateEmpresa", ex.Message, null);
                throw;
            }
        }
    }
}