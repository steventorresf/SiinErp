using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Ventas
{
    public class CajaBusiness : ICajaBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public CajaBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Caja> GetCajasById(int IdCajero)
        {
            try
            {
                List<Caja> Lista = (from ca in context.Caja.Where(x => x.IdDetCajero == IdCajero && !x.Estado.Equals(Constantes.EstadoInactivo))
                                    join tu in context.TablasDetalles on ca.IdTurno equals tu.IdDetalle
                                    select new Caja()
                                    {
                                        IdCaja = ca.IdCaja,
                                        IdEmpresa = ca.IdEmpresa,
                                        IdTurno = ca.IdTurno,
                                        NombreTurno = tu.Descripcion,
                                        Periodo = ca.Periodo,
                                        FechaDoc = ca.FechaDoc,
                                        sFechaDoc = ca.FechaDoc.ToString("dd-MM-yyyy"),
                                        SaldoInicial = ca.SaldoInicial,
                                        SaldoFinal = ca.SaldoFinal,
                                        Comentario = ca.Comentario,
                                        Estado = ca.Estado,
                                        NombreEstado = ca.Estado.Equals("C") ? "Cerrada" : "Abierta",
                                        FechaCreacion = ca.FechaCreacion,
                                        CreadoPor = ca.CreadoPor,
                                        FechaModificado = ca.FechaModificado,
                                        ModificadoPor = ca.ModificadoPor,
                                    }).OrderByDescending(x => x.FechaCreacion).Take(30).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetCajasById", ex.Message, null);
                throw;
            }
        }

        public void Create(Caja entity)
        {
            try
            {
                entity.FechaDoc = DateTimeOffset.Now;
                entity.FechaCreacion = DateTimeOffset.Now;
                entity.Periodo = entity.FechaDoc.ToString("yyyyMM");
                context.Caja.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateCaja", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdCaja, Caja data)
        {
            try
            {
                Caja entity = context.Caja.Find(IdCaja);
                entity.SaldoFinal = data.SaldoFinal;
                entity.Estado = Constantes.EstadoCerrado;
                entity.ModificadoPor = data.ModificadoPor;
                entity.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateCerrarCaja", ex.Message, null);
                throw;
            }
        }

        public int GetIdCajaActiva(int IdCajero)
        {
            try
            {
                int IdCaja = 0;
                List<Caja> Lista = context.Caja.Where(x => x.IdDetCajero == IdCajero && x.Estado.Equals("A")).ToList();
                if (Lista.Count > 0)
                {
                    if (Lista.Count > 1)
                    {
                        IdCaja = -1;
                    }
                    else { IdCaja = Lista[0].IdCaja; }
                }
                return IdCaja;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetIdCajaActiva", ex.Message, null);
                throw;
            }
        }

        public int GetLastIdDetCajeroByUsu(string NombreUsuario, int IdEmpresa)
        {
            try
            {
                int? IdDetCajero = (from ca in context.Caja.Where(x => x.Estado.Equals("A") && x.IdEmpresa == IdEmpresa)
                                    join cd in context.CajaDetalle on ca.IdCaja equals cd.IdCaja
                                    where cd.CreadoPor.Equals(NombreUsuario)
                                    orderby cd.FechaCreacion descending
                                    select ca.IdDetCajero).FirstOrDefault();
                return IdDetCajero != null ? Convert.ToInt32(IdDetCajero) : -1;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetLastIdDetCajeroByUsu", ex.Message, null);
                throw;
            }
        }

        public decimal GetSaldoEnCajaActual(int IdCaja)
        {
            try
            {
                decimal SaldoEnCaja = 0;
                Caja entity = context.Caja.Find(IdCaja);
                List<decimal> listValor = context.CajaDetalle.Where(x => x.IdCaja == IdCaja && x.Efectivo)
                                                             .Select(x => x.Valor * x.Transaccion).ToList();
                SaldoEnCaja = entity.SaldoInicial;
                if (listValor.Count > 0)
                {
                    SaldoEnCaja += listValor.Sum(y => y);
                }
                return SaldoEnCaja;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetSaldoEnCajaActual", ex.Message, null);
                throw;
            }
        }

        public Caja GetCajaImpresion(int IdCaja)
        {
            try
            {
                Caja entity = (from ca in context.Caja.Where(x => x.IdCaja == IdCaja)
                               join em in context.Empresas on ca.IdEmpresa equals em.IdEmpresa
                               join cj in context.TablasDetalles on ca.IdDetCajero equals cj.IdDetalle
                               join tu in context.TablasDetalles on ca.IdTurno equals tu.IdDetalle
                               select new Caja()
                               {
                                   IdCaja = ca.IdCaja,
                                   IdEmpresa = ca.IdEmpresa,
                                   FechaDoc = ca.FechaDoc,
                                   sFechaDoc = ca.FechaDoc.ToString("dd/MM/yyyy"),
                                   NombreEmpresa = em.RazonSocial,
                                   SaldoInicial = ca.SaldoInicial,
                                   SaldoFinal = ca.SaldoFinal,
                                   CreadoPor = ca.CreadoPor,
                                   NombreCaja = cj.Descripcion,
                                   NombreTurno = tu.Descripcion,
                               }).FirstOrDefault();
                List<CajaDetalle> ListaDetalle = (from cd in context.CajaDetalle.Where(x => x.IdCaja == IdCaja)
                                                  join fp in context.TablasDetalles on cd.IdDetFormaPago equals fp.IdDetalle into joined
                                                  from j in joined.DefaultIfEmpty()
                                                  select new CajaDetalle()
                                                  {
                                                      IdCajaDetalle = cd.IdCajaDetalle,
                                                      IdCaja = cd.IdCaja,
                                                      CreadoPor = cd.CreadoPor,
                                                      FechaCreacion = cd.FechaCreacion,
                                                      Transaccion = cd.Transaccion,
                                                      Valor = cd.Valor,
                                                      IdDetFormaPago = cd.IdDetFormaPago,
                                                      Comentario = cd.Comentario,
                                                      Estado = cd.Estado,
                                                      TipoDoc = cd.TipoDoc,
                                                      NumDoc = cd.NumDoc,
                                                      Efectivo = cd.Efectivo,
                                                      NombreFormaPago = j == null ? (cd.TipoDoc.Equals(Constantes.VenDocEgresoCaja) ? "Egresos" : "Ingresos") : j.Descripcion,
                                                  }).ToList();
                entity.ListaDetalle = ListaDetalle;
                entity.ListaResumen = ListaDetalle.GroupBy(x => new { x.NombreFormaPago })
                                                  .Select(x => new CajaDetalle()
                                                  {
                                                      NombreFormaPago = x.Key.NombreFormaPago,
                                                      Valor = x.Sum(y => y.Valor * y.Transaccion),
                                                  }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ImprimirCaja", ex.Message, null);
                throw;
            }
        }
    }
}