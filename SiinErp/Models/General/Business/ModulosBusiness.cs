using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class ModulosBusiness
    {
        public List<Modulos> GetModulos()
        {
            try
            {
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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
