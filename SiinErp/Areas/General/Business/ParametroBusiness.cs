using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class ParametroBusiness : IParametroBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ParametroBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Parametro> GetParametros()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
