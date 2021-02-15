using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ModuloBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Modulo> GetModulos()
        {
            try
            {
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