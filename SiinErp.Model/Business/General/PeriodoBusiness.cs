using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class PeriodoBusiness : IPeriodoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public PeriodoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public void Create(Periodo entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(entity.PeriodoAnterior))
                {
                    Periodo Anterior = context.Periodos.FirstOrDefault(x => x.CodModulo.Equals(entity.CodModulo) &&
                                                                             x.PeriodoActual.Equals(entity.PeriodoAnterior) &&
                                                                             x.IdEmpresa == entity.IdEmpresa);
                    Anterior.Situacion = Constantes.CodSituacion_Cerrado;
                    context.SaveChanges();
                }
                entity.FechaFin = entity.FechaInicio.AddMonths(1).AddDays(-1);
                entity.FechaCreacion = DateTimeOffset.Now;
                context.Periodos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatePeriodo", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdPeriodo, Periodo entity)
        {
            try
            {
                Periodo ob = context.Periodos.Find(IdPeriodo);
                ob.Situacion = entity.Situacion;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdatePeriodo", ex.Message, null);
                throw;
            }
        }

        public List<Periodo> GetPeriodos(int IdEmpresa)
        {
            try
            {
                List<Periodo> Lista = (from pe in context.Periodos.Where(x => x.IdEmpresa == IdEmpresa)
                                       join mo in context.Modulos on pe.CodModulo equals mo.CodModulo
                                       select new Periodo()
                                       {
                                           IdPeriodo = pe.IdPeriodo,
                                           IdEmpresa = pe.IdEmpresa,
                                           CodModulo = pe.CodModulo,
                                           PeriodoAnterior = pe.PeriodoAnterior,
                                           PeriodoActual = pe.PeriodoActual,
                                           FechaInicio = pe.FechaInicio,
                                           FechaFin = pe.FechaFin,
                                           FechaCreacion = pe.FechaCreacion,
                                           Situacion = pe.Situacion,
                                           IdUsuario = pe.IdUsuario,
                                           NombreModulo = mo.Descripcion,
                                       }).OrderBy(x => x.CodModulo).OrderByDescending(x => x.PeriodoActual).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPeriodos", ex.Message, null);
                throw;
            }
        }

        public string[] GetSiguientePeriodo(int IdEmpresa, string CodModulo)
        {
            try
            {
                string[] periodos = new string[2];
                Periodo entity = context.Periodos.Where(x => x.CodModulo.Equals(CodModulo) && x.Situacion.Equals(Constantes.CodSituacion_Abierto) && x.IdEmpresa == IdEmpresa).OrderByDescending(x => x.PeriodoActual).FirstOrDefault();
                if (entity != null)
                {
                    periodos[0] = entity.PeriodoActual;
                    periodos[1] = entity.FechaFin.AddDays(1).ToString("yyyyMM");
                }
                else
                {
                    periodos[0] = "";
                    periodos[1] = "";
                }
                return periodos;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetUltimoPeriodo", ex.Message, null);
                throw;
            }
        }
    }
}