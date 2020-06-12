using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class ParametrosBusiness
    {
        public List<Parametros> GetParametros()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Parametros> Lista = context.Parametros.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetParametros", ex.Message, null);
                throw;
            }
        }

        public void Create(Parametros entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Parametros.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateParametro", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdParametro, Parametros entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Parametros ob = context.Parametros.Find(IdParametro);
                ob.CodigoParam = entity.CodigoParam;
                ob.Descripcion = entity.Descripcion;
                ob.ValorParam = entity.ValorParam;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateParametro", ex.Message, null);
                throw;
            }
        }
    }
}
