using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public DepartamentoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            try
            {
                List<Departamento> Lista = (from de in context.Departamentos
                                            join pa in context.Paises on de.IdPais equals pa.IdPais
                                            select new Departamento()
                                            {
                                                IdDepartamento = de.IdDepartamento,
                                                NombreDepartamento = de.NombreDepartamento,
                                                CodigoDane = de.CodigoDane,
                                                IdPais = de.IdPais,
                                                NombrePais = pa.NombrePais,
                                            }).OrderBy(x => x.NombreDepartamento).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetDepartamentos", ex.Message, null);
                throw;
            }
        }

        public void Create(Departamento entity)
        {
            try
            {
                context.Departamentos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateDepartamento", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdDepartamento, Departamento entity)
        {
            try
            {
                Departamento ob = context.Departamentos.Find(IdDepartamento);
                ob.NombreDepartamento = entity.NombreDepartamento;
                ob.CodigoDane = entity.CodigoDane;
                ob.IdPais = entity.IdPais;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateDepartamento", ex.Message, null);
                throw;
            }
        }
    }
}