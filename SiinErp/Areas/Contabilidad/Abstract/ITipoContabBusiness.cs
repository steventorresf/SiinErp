using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Abstract
{
    public interface ITipoContabBusiness
    {
        List<TipoContab> GetTiposContab(int IdEmpresa);

        TipoContab GetTipoContab(int IdEmpresa, string TipoDoc);

        void Create(TipoContab entity);

        void Update(int IdTipoDoc, TipoContab entity);
    }
}
