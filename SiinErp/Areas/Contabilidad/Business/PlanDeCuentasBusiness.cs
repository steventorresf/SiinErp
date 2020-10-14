using SiinErp.Models;
using SiinErp.Areas.Contabilidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class PlanDeCuentasBusiness
    {
        public List<PlanDeCuentas> GetPlanDeCuentas(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<PlanDeCuentas> Lista = context.PlanDeCuentas.OrderBy(x => x.CodCuenta).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPlanContab", ex.Message, null);
                throw;
            }
        }


        public PlanDeCuentas GetCuenta(int IdEmpresa, string CodCuenta)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                PlanDeCuentas entity = context.PlanDeCuentas.FirstOrDefault(x => x.IdEmpresa == IdEmpresa && x.CodCuenta.Equals(CodCuenta));
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPlanContab", ex.Message, null);
                throw;
            }
        }

        public void Create(PlanDeCuentas entity)
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
                ErroresBusiness.Create("CreatePlanContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdCuentaContable, PlanDeCuentas entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                PlanDeCuentas ob = context.PlanDeCuentas.Find(IdCuentaContable);
                ob.CodCuenta = entity.CodCuenta;
                ob.NivelCuenta = entity.NivelCuenta;
                ob.NombreCuenta = entity.NombreCuenta;
                ob.TerceroSN = entity.TerceroSN;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdatePlanContab", ex.Message, null);
                throw;
            }
        }


    }
}