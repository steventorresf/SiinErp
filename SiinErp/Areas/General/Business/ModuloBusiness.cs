using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ModuloBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Modulo> GetModulos()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Modulo> Lista = context.Modulos.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetModulos", ex.Message, null);
                throw;
            }
        }

        public List<Modulo> GetModulosPer()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Modulo> Lista = context.Modulos.Where(x => x.Periodo == true).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetModulosPer", ex.Message, null);
                throw;
            }
        }
    }
}
