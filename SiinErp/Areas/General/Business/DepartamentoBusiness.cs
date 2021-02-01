using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public DepartamentoBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }

        public List<Departamento> GetDepartamentos()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
