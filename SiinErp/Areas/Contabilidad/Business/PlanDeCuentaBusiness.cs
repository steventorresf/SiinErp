using SiinErp.Models;
using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.Contabilidad.Abstract;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class PlanDeCuentaBusiness : IPlanDeCuentaBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public PlanDeCuentaBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<PlanDeCuenta> GetPlanDeCuentas(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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