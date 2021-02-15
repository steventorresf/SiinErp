using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class ParametroBusiness : IParametroBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ParametroBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Parametro> GetParametros()
        {
            try
            {
                List<Parametro> Lista = context.Parametros.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetParametros", ex.Message, null);
                throw;
            }
        }

        public void Create(Parametro entity)
        {
            try
            {
                context.Parametros.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateParametro", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdParametro, Parametro entity)
        {
            try
            {
                Parametro ob = context.Parametros.Find(IdParametro);
                ob.CodigoParam = entity.CodigoParam;
                ob.Descripcion = entity.Descripcion;
                ob.ValorParam = entity.ValorParam;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateParametro", ex.Message, null);
                throw;
            }
        }
    }
}