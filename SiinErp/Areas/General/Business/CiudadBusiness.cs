using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class CiudadBusiness : ICiudadBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public CiudadBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }

        public List<Ciudad> GetCiudades(int IdDep)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Ciudad> Lista = context.Ciudades.Where(x => x.IdDepartamento == IdDep).OrderBy(x => x.NombreCiudad).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetCiudades", ex.Message, null);
                throw;
            }
        }

        public void Create(Ciudad entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Ciudades.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateCiudad", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdCiudad, Ciudad entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Ciudad ob = context.Ciudades.Find(IdCiudad);
                ob.NombreCiudad = entity.NombreCiudad;
                ob.CodigoDane = entity.CodigoDane;
                ob.IdDepartamento = entity.IdDepartamento;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateCiudad", ex.Message, null);
                throw;
            }
        }
    }
}
