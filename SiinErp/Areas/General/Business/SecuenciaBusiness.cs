using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class SecuenciaBusiness : ISecuenciaBusiness
    {
        public string GetPrefijoSecuencia(string Prefijo, int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.Prefijo.Equals(Prefijo) && x.IdEmpresa == IdEmpresa);
                string StrSecuencia = Util.GetPrefijoSecuencia(entitySec.Prefijo, entitySec.NoSecuencia + 1, entitySec.Longitud);
                return StrSecuencia;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
