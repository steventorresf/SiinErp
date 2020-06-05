using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class PaisesBusiness
    {
        public List<Paises> GetPaises()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Paises> Lista = context.Paises.OrderBy(x => x.NombrePais).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPaises", ex.Message, null);
                throw;
            }
        }

        public void Create(Paises entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Paises.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatePais", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdPais, Paises entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Paises ob = context.Paises.Find(IdPais);
                ob.NombrePais = entity.NombrePais;
                ob.CodigoDane = entity.CodigoDane;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdatePais", ex.Message, null);
                throw;
            }
        }
    }
}
