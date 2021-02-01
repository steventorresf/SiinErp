using SiinErp.Areas.Cartera.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Abstract
{
    public interface IConceptoBusiness
    {
        List<Concepto> GetConceptos(int IdEmpresa);

        List<Concepto> GetConceptosByTipoDoc(int IdTipoDoc);

        void Create(Concepto entity);

        void Update(int IdConcepto, Concepto entity);
    }
}
