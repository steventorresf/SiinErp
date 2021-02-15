using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class PaisBusiness : IPaisBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public PaisBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Pais> GetPaises()
        {
            try
            {
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