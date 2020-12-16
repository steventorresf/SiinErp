using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Business
{
    public class CajaBusiness
    {
        public List<Caja> GetCajas(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                //Tablas TabCajero = context.Tablas.FirstOrDefault(x => x.CodTabla.Equals(Constantes.TabCajeros));
                //List<Caja> Lista = (from cj in context.TablasDetalles.Where(x => x.IdTabla == TabCajero.IdTabla && x.IdEmpresa == IdEmp)
                //                    join ca in context.Caja.Where(x => x.Estado.Equals(Constantes.EstadoActivo) && x.IdEmpresa == IdEmp) on cj.IdDetalle equals ca.IdCajero into joined
                //                    from j in joined.DefaultIfEmpty()
                //                    select new Caja()
                //                    {
                //                        IdCaja = j == null ? 0 : j.IdCaja,
                //                        IdCajero = cj.IdDetalle,
                //                        NombreCajero = cj.Descripcion,
                //                        Estado = j == null ? "C" : "A",
                //                        NombreEstado = j == null ? "Cerrada" : "Abierta",
                //                        CreadoPor = j == null ? "" : j.CreadoPor,
                //                        IdEmpresa = cj.IdEmpresa,
                //                        SaldoInicial = j == null ? 0 : j.SaldoInicial,
                //                        IdTurno = j == null ? 0 : j.IdTurno,
                //                        sFechaDoc = j == null ? "" : j.FechaCreacion.ToString("MM-dd-yyyy"),
                //                    }).OrderBy(x => x.NombreCajero).ToList();

                List<Caja> Lista = (from ca in context.Caja.Where(x => x.IdEmpresa == IdEmp && !x.Estado.Equals(Constantes.EstadoInactivo))
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
                ErroresBusiness.Create("GetCajas", ex.Message, null);
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

                SiinErpContext context = new SiinErpContext();
                context.Caja.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateCaja", ex.Message, null);
                throw;
            }
        }


        public void Update(int IdCaja, Caja data)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Caja entity = context.Caja.Find(IdCaja);
                entity.SaldoFinal = data.SaldoFinal;
                entity.Estado = Constantes.EstadoCerrado;
                entity.ModificadoPor = data.ModificadoPor;
                entity.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateCerrarCaja", ex.Message, null);
                throw;
            }
        }

        public int GetIdCajaActiva(int IdEmpresa)
        {
            try
            {
                int IdCaja = 0;
                SiinErpContext context = new SiinErpContext();
                List<Caja> Lista = context.Caja.Where(x => x.IdEmpresa == IdEmpresa && x.Estado.Equals("A")).ToList();
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
                ErroresBusiness.Create("GetIdCajaActiva", ex.Message, null);
                throw;
            }
        }

        public Caja GetCajaImpresion(int IdCaja)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Caja entity = (from ca in context.Caja.Where(x => x.IdCaja == IdCaja)
                               join em in context.Empresas on ca.IdEmpresa equals em.IdEmpresa
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
                                                      Valor = cd.Valor * cd.Transaccion,
                                                      IdDetFormaPago = cd.IdDetFormaPago,
                                                      Comentario = cd.Comentario,
                                                      Estado = cd.Estado,
                                                      NombreFormaPago = j == null ? "Egreso" : j.Descripcion,
                                                  }).ToList();
                entity.ListaResumen = ListaDetalle.GroupBy(x => new { x.NombreFormaPago })
                                                  .Select(x => new CajaDetalle()
                                                  {
                                                      NombreFormaPago = x.Key.NombreFormaPago,
                                                      Valor = x.Sum(y => y.Valor),
                                                  }).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ImprimirCaja", ex.Message, null);
                throw;
            }
        }
    }
}
