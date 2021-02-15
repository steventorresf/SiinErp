using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class CiudadBusiness : ICiudadBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public CiudadBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Ciudad> GetCiudades(int IdDep)
        {
            try
            {
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