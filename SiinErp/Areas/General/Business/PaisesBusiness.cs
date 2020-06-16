using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class PaisesBusiness
    {
        public List<Paises> GetPaises()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
