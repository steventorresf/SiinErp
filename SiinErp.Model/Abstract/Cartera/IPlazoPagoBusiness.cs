using SiinErp.Model.Entities.Cartera;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Cartera
{
    public interface IPlazoPagoBusiness
    {
        List<PlazoPago> GetPlazosPagos(int IdEmpresa);

        void Create(PlazoPago entity);

        void Update(int IdPlazoPago, PlazoPago entity);
    }
}