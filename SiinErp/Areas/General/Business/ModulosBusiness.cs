using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class ModulosBusiness
    {
        public List<Modulos> GetModulos()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Modulos> Lista = context.Modulos.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetModulos", ex.Message, null);
                throw;
            }
        }

        public List<Modulos> GetModulosPer()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Modulos> Lista = context.Modulos.Where(x => x.Periodo == true).OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetModulosPer", ex.Message, null);
                throw;
            }
        }
    }
}
