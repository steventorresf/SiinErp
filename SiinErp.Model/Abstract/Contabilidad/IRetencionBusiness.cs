using SiinErp.Model.Entities.Contabilidad;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Contabilidad
{
    public interface IRetencionBusiness
    {
        List<Retencion> GetRetenciones(int IdEmpresa);

        Retencion GetTipoRet(int IdEmpresa, string TipoDoc);

        void Create(Retencion entity);

        void Update(int IdTipoDoc, Retencion entity);
    }
}