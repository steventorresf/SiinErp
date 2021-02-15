using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Contabilidad;

namespace SiinErp.Model.Business.Contabilidad
{
    public class PlanDeCuentaBusiness : IPlanDeCuentaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public PlanDeCuentaBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<PlanDeCuenta> GetPlanDeCuentas(int IdEmpresa)
        {
            try
            {
                List<PlanDeCuenta> Lista = context.PlanDeCuentas.Where(x => x.IdEmpresa == IdEmpresa).OrderBy(x => x.CodCuenta).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPlanContab", ex.Message, null);
                throw;
            }
        }

        public List<PlanDeCuenta> GetPlanDeCuentasByNivel(int IdEmpresa, string Nivel)
        {
            try
            {
                List<PlanDeCuenta> Lista = context.PlanDeCuentas.Where(x => x.IdEmpresa == IdEmpresa && x.NivelCuenta.Equals(Nivel)).OrderBy(x => x.CodCuenta).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPlanContabByNivel", ex.Message, null);
                throw;
            }
        }

        public PlanDeCuenta GetCuenta(int IdEmpresa, string CodCuenta)
        {
            try
            {
                PlanDeCuenta entity = context.PlanDeCuentas.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.CodCuenta.Equals(CodCuenta));
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPlanContab", ex.Message, null);
                throw;
            }
        }

        public void Create(PlanDeCuenta entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                context.PlanDeCuentas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatePlanContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdCuentaContable, PlanDeCuenta entity)
        {
            try
            {
                PlanDeCuenta ob = context.PlanDeCuentas.Find(IdCuentaContable);
                ob.CodCuenta = entity.CodCuenta;
                ob.NivelCuenta = entity.NivelCuenta;
                ob.NombreCuenta = entity.NombreCuenta;
                ob.TerceroSN = entity.TerceroSN;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdatePlanContab", ex.Message, null);
                throw;
            }
        }
    }
}