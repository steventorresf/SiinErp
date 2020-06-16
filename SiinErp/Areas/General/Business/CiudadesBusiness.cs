using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class CiudadesBusiness
    {
        public List<Ciudades> GetCiudades(int IdDep)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Ciudades> Lista = context.Ciudades.Where(x => x.IdDepartamento == IdDep).OrderBy(x => x.NombreCiudad).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetCiudades", ex.Message, null);
                throw;
            }
        }

        public void Create(Ciudades entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Ciudades.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateCiudad", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdCiudad, Ciudades entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Ciudades ob = context.Ciudades.Find(IdCiudad);
                ob.NombreCiudad = entity.NombreCiudad;
                ob.CodigoDane = entity.CodigoDane;
                ob.IdDepartamento = entity.IdDepartamento;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateCiudad", ex.Message, null);
                throw;
            }
        }
    }
}
