using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class EmpresasBusiness
    {
        public List<Empresas> GetEmpresas()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Empresas> Lista = context.Empresas.OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }
    }
}
