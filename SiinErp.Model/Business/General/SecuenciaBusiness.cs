using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Business.General
{
    
    public class SecuenciaBusiness : ISecuenciaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public SecuenciaBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public string GetPrefijoSecuencia(string Prefijo, int IdEmpresa)
        {
            try
            {
                Secuencia entitySec = context.Secuencia.FirstOrDefault(x => x.Prefijo.Equals(Prefijo) && x.IdEmpresa == IdEmpresa);
                string StrSecuencia = Seguridad.GetPrefijoSecuencia(entitySec.Prefijo, entitySec.NoSecuencia + 1, entitySec.Longitud);
                return StrSecuencia;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
