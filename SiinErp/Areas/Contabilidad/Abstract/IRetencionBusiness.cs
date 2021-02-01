using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Abstract
{
    public interface IRetencionBusiness
    {
        List<Retencion> GetRetenciones(int IdEmpresa);

        Retencion GetTipoRet(int IdEmpresa, string TipoDoc);

        void Create(Retencion entity);

        void Update(int IdTipoDoc, Retencion entity);
    }
}
