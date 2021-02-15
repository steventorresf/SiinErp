using SiinErp.Model.Entities.Cartera;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Cartera
{
    public interface IConceptoBusiness
    {
        List<Concepto> GetConceptos(int IdEmpresa);

        List<Concepto> GetConceptosByTipoDoc(int IdTipoDoc);

        void Create(Concepto entity);

        void Update(int IdConcepto, Concepto entity);
    }
}