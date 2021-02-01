using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Abstract
{
    public interface IPlanDeCuentaBusiness
    {
        List<PlanDeCuenta> GetPlanDeCuentas(int IdEmpresa);

        List<PlanDeCuenta> GetPlanDeCuentasByNivel(int IdEmpresa, string Nivel);

        PlanDeCuenta GetCuenta(int IdEmpresa, string CodCuenta);

        void Create(PlanDeCuenta entity);

        void Update(int IdCuentaContable, PlanDeCuenta entity);
    }
}
