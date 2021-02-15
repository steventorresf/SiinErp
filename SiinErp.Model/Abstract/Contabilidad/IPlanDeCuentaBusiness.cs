using SiinErp.Model.Entities.Contabilidad;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Contabilidad
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