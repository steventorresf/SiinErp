using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Abstract
{
    public interface IComprobanteBusiness
    {
        List<Comprobante> GetAll(int IdEmpresa, string FechaI, string FechaF);

        void Create(JObject data);

        void Update(int IdComprobante, JObject data);

        void Anular(int IdComprobante, string ModificadoPor);
    }
}
