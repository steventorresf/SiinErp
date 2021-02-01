using SiinErp.Areas.Cartera.Abstract;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Business
{
    public class MovimientoCarBusiness : IMovimientoCarBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public MovimientoCarBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public void Create(MovimientoCar entity, List<Movimiento> listDetalleFac)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    TipoDocumento tipoDoc = context.TiposDocumentos.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc) && x.IdEmpresa == entity.IdEmpresa);
                    tipoDoc.NumDoc++;
                    context.SaveChanges();

                    entity.NumDoc = tipoDoc.NumDoc;
                    entity.Periodo = entity.FechaDoc.ToString("yyyyMM");
                    entity.FechaCreacion = DateTimeOffset.Now;

                    context.MovimientosCar.Add(entity);
                    context.SaveChanges();

                    MovimientoCar ob = context.MovimientosCar.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                    List<MovimientoCarDetalle> listDetalleMov = new List<MovimientoCarDetalle>();

                    foreach (Movimiento f in listDetalleFac)
                    {
                        MovimientoCarDetalle movdet = new MovimientoCarDetalle();
                        movdet.IdMovimiento = ob.IdMovimiento;
                        movdet.TipoDocAfectado = f.TipoDoc;
                        movdet.NumDocAfectado = f.NumDoc;
                        movdet.ValorBase = f.VrPagar;
                        movdet.ValorCargo = f.VrPagar;
                        listDetalleMov.Add(movdet);

                        Movimiento entityMov = context.Movimientos.Find(f.IdMovimiento);
                        entityMov.ValorSaldo += f.VrPagar * tipoDoc.IdDetTransaccion;
                        context.SaveChanges();
                    }
                    context.MovimientosCarDetalles.AddRange(listDetalleMov);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateMovimientoCar", ex.Message, null);
                throw;
            }
        }

        public List<MovimientoCar> GetAll(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<MovimientoCar> Lista = (from mov in context.MovimientosCar.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.Estado.Equals(Constantes.EstadoActivo))
                                              join cli in context.Terceros on mov.IdCliente equals cli.IdTercero
                                              join con in context.Conceptos on mov.IdConcepto equals con.IdConcepto
                                              select new MovimientoCar()
                                              {
                                                  IdMovimiento = mov.IdMovimiento,
                                                  IdEmpresa = mov.IdEmpresa,
                                                  TipoDoc = mov.TipoDoc,
                                                  NumDoc = mov.NumDoc,
                                                  AfectaCartera = mov.AfectaCartera,
                                                  IdCliente = mov.IdCliente,
                                                  Periodo = mov.Periodo,
                                                  FechaDoc = mov.FechaDoc,
                                                  IdVendedor = mov.IdVendedor,
                                                  ValorCargo = mov.ValorCargo,
                                                  ValorIva = mov.ValorIva,
                                                  ValorOtros = mov.ValorOtros,
                                                  ValorReteFuente = mov.ValorReteFuente,
                                                  ValorTotal = mov.ValorTotal,
                                                  Comentarios = mov.Comentarios,
                                                  CreadoPor = mov.CreadoPor,
                                                  Estado = mov.Estado,
                                                  FechaCreacion = mov.FechaCreacion,
                                                  IdConcepto = mov.IdConcepto,
                                                  NombreConcepto = con.Descripcion,
                                                  NombreTercero = cli.NombreTercero,
                                              }).OrderBy(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllMovimientoCar", ex.Message, null);
                throw;
            }
        }

        public void Anular(int IdMov, string NomUsu)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    MovimientoCar entity = context.MovimientosCar.Find(IdMov);
                    entity.Estado = Constantes.EstadoInactivo;
                    entity.ModificadoPor = NomUsu;
                    entity.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    List<MovimientoCarDetalle> Lista = context.MovimientosCarDetalles.Where(x => x.IdMovimiento == IdMov).ToList();
                    foreach(MovimientoCarDetalle movdet in Lista)
                    {
                        Movimiento entityMov = context.Movimientos.FirstOrDefault(x => x.NumDoc == movdet.NumDocAfectado && x.TipoDoc.Equals(movdet.TipoDocAfectado) && x.IdEmpresa == entity.IdEmpresa);
                        entityMov.ValorSaldo += movdet.ValorCargo;
                        context.SaveChanges();
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("AnularMovimientoCar", ex.Message, null);
                throw;
            }
        }
    }
}
