using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
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

        public CiudadBusiness(IErrorBusiness _errorBusiness, SiinErpContext _context)
        {
            this.errorBusiness = _errorBusiness;
            this.context = _context;
        }

        public void Create(Ciudad entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                entity.FechaModificado = DateTimeOffset.Now;
                context.Ciudades.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateCiudad", ex, null);
                throw;
            }
        }

        public List<Ciudad> GetAll()
        {
            try
            {
                List<Ciudad> Lista = context.Ciudades.OrderBy(x => x.NombreCiudad).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllCiudad", ex, null);
                throw;
            }
        }

        public List<Ciudad> GetByIdDepartamento(int IdDepartamento)
        {
            try
            {
                List<Ciudad> Lista = context.Ciudades.Where(x => x.IdDepartamento == IdDepartamento).OrderBy(x => x.NombreCiudad).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByIdDepartamentoCiudad", ex, null);
                throw;
            }
        }

        public void Update(int IdCiudad, Ciudad entity)
        {
            try
            {
                Ciudad obCiu = context.Ciudades.Find(IdCiudad);
                obCiu.NombreCiudad = entity.NombreCiudad;
                obCiu.CodigoDane = entity.CodigoDane;
                obCiu.ModificadoPor = entity.ModificadoPor;
                obCiu.EstadoFila = entity.EstadoFila;
                obCiu.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateCiudad", ex, null);
                throw;
            }
        }

        public void Delete(int IdCiudad)
        {
            try
            {
                Ciudad obCiu = context.Ciudades.Find(IdCiudad);
                context.Ciudades.Remove(obCiu);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("DeleteCiudad", ex, null);
                throw;
            }
        }
    }
}