using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class DepartamentosBusiness
    {
        public List<Departamentos> GetDepartamentos()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Departamentos> Lista = (from de in context.Departamentos
                                             join pa in context.Paises on de.IdPais equals pa.IdPais
                                             select new Departamentos()
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
                ErroresBusiness.Create("GetDepartamentos", ex.Message, null);
                throw;
            }
        }

        public void Create(Departamentos entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Departamentos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateDepartamento", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdDepartamento, Departamentos entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Departamentos ob = context.Departamentos.Find(IdDepartamento);
                ob.NombreDepartamento = entity.NombreDepartamento;
                ob.CodigoDane = entity.CodigoDane;
                ob.IdPais = entity.IdPais;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateDepartamento", ex.Message, null);
                throw;
            }
        }

    }
}
