using SiinErp.Model.Entities.Contabilidad;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Contabilidad
{
    public interface ITipoContabBusiness
    {
        List<TipoContab> GetTiposContab(int IdEmpresa);

        TipoContab GetTipoContab(int IdEmpresa, string TipoDoc);

        void Create(TipoContab entity);

        void Update(int IdTipoDoc, TipoContab entity);
    }
}