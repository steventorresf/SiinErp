using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class PaisBusiness : IPaisBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public PaisBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Pais> GetPaises()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Pais> Lista = context.Paises.OrderBy(x => x.NombrePais).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPaises", ex.Message, null);
                throw;
            }
        }

        public void Create(Pais entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Paises.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatePais", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdPais, Pais entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Pais ob = context.Paises.Find(IdPais);
                ob.NombrePais = entity.NombrePais;
                ob.CodigoDane = entity.CodigoDane;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdatePais", ex.Message, null);
                throw;
            }
        }
    }
}
