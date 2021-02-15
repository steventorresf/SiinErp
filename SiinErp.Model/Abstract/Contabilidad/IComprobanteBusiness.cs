using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.Contabilidad;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Contabilidad
{
    public interface IComprobanteBusiness
    {
        List<Comprobante> GetAll(int IdEmpresa, string FechaI, string FechaF);

        void Create(JObject data);

        void Update(int IdComprobante, JObject data);

        void Anular(int IdComprobante, string ModificadoPor);
    }
}