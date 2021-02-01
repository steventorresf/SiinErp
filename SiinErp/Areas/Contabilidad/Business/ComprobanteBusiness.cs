using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Abstract;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Contabilidad.Business
{
    public class ComprobanteBusiness : IComprobanteBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ComprobanteBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Comprobante> GetAll(int IdEmpresa, string FechaI, string FechaF)
        {
            try
            {
                DateTimeOffset FechaIni = DateTimeOffset.Parse(FechaI).ToOffset(new TimeSpan(-5, 0, 0));
                DateTimeOffset FechaFin = DateTimeOffset.Parse(FechaF).ToOffset(new TimeSpan(-5, 0, 0));

                SiinErpContext context = new SiinErpContext();
                List<Comprobante> Lista = (from cp in context.Comprobantes.Where(x => x.IdEmpresa == IdEmpresa && x.FechaDoc >= FechaIni && x.FechaDoc <= FechaFin && x.Estado.Equals(Constantes.EstadoActivo))
                                            select new Comprobante()
                                            {
                                                IdComprobante = cp.IdComprobante,
                                                TipoDoc = cp.TipoDoc,
                                                NumDoc = cp.NumDoc,
                                                FechaDoc = cp.FechaDoc,
                                                IdEmpresa = cp.IdEmpresa,
                                                CreadoPor = cp.CreadoPor,
                                                Estado = cp.Estado,
                                                FechaCreacion = cp.FechaCreacion,
                                                FechaModificado = cp.FechaModificado,
                                                ModificadoPor = cp.ModificadoPor,
                                                Periodo = cp.Periodo,
                                                sFechaDoc = cp.FechaDoc.ToString("dd/MM/yyyy"),
                                            }).OrderBy(x => x.FechaDoc).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllComprobantesContab", ex.Message, null);
                throw;
            }
        }


        public void Create(JObject data)
        {
            try
            {
                Comprobante entity = data["entity"].ToObject<Comprobante>();
                List<ComprobanteDetalle> listEntity = data["listEntity"].ToObject<List<ComprobanteDetalle>>();

                SiinErpContext context = new SiinErpContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    TipoContab entityTipoDoc = context.TiposContab.FirstOrDefault(x => x.TipoDoc.Equals(entity.TipoDoc));
                    entityTipoDoc.NumDoc++;
                    context.SaveChanges();

                    entity.NumDoc = entityTipoDoc.NumDoc;
                    entity.FechaDoc = entity.FechaDoc.ToOffset(new TimeSpan(-5, 0, 0));
                    entity.FechaCreacion = DateTimeOffset.Now;
                    context.Comprobantes.Add(entity);
                    context.SaveChanges();

                    Comprobante obEntity = context.Comprobantes.FirstOrDefault(x => x.NumDoc == entity.NumDoc && x.TipoDoc.Equals(entity.TipoDoc));
                    foreach(ComprobanteDetalle d in listEntity)
                    {
                        d.IdDetalleComprobante = 0;
                        d.IdComprobante = obEntity.IdComprobante;
                        d.FechaCreacion = DateTimeOffset.Now;
                    }

                    context.ComprobantesDetalles.AddRange(listEntity);
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateComprobantesContab", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdComprobante, JObject data)
        {
            try
            {
                Comprobante entity = data["entity"].ToObject<Comprobante>();
                List<ComprobanteDetalle> listEntity = data["listEntity"].ToObject<List<ComprobanteDetalle>>();

                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    entity.FechaDoc = entity.FechaDoc.ToOffset(new TimeSpan(-5, 0, 0));
                    Comprobante ob = context.Comprobantes.Find(IdComprobante);
                    if (ob.FechaDoc != entity.FechaDoc)
                    {
                        ob.FechaDoc = entity.FechaDoc;
                        ob.Periodo = entity.Periodo;
                        ob.ModificadoPor = entity.ModificadoPor;
                        ob.FechaModificado = DateTimeOffset.Now;
                        context.SaveChanges();
                    }

                    foreach(ComprobanteDetalle d in listEntity)
                    {
                        switch (d.Modo)
                        {
                            case "A":
                                {
                                    d.IdDetalleComprobante = 0;
                                    d.IdComprobante = entity.IdComprobante;
                                    d.FechaCreacion = DateTimeOffset.Now;
                                    context.ComprobantesDetalles.Add(d);
                                    context.SaveChanges();
                                    break;
                                }
                            case "E":
                                {
                                    ComprobanteDetalle entityDet = context.ComprobantesDetalles.Find(d.IdDetalleComprobante);
                                    entityDet.Detalle = d.Detalle;
                                    entityDet.IdCuentaContable = d.IdCuentaContable;
                                    entityDet.IdTercero = d.IdTercero;
                                    entityDet.DebCred = d.DebCred;
                                    entityDet.IdDetCenCosto = d.IdDetCenCosto;
                                    entityDet.IdRetencion = d.IdRetencion;
                                    entityDet.Valor = d.Valor;
                                    entityDet.ModificadoPor = entity.ModificadoPor;
                                    entityDet.FechaModificado = DateTimeOffset.Now;
                                    context.SaveChanges();
                                    break;
                                }
                            case "X":
                                {
                                    ComprobanteDetalle entityDet = context.ComprobantesDetalles.Find(d.IdDetalleComprobante);
                                    entityDet.Estado = Constantes.EstadoInactivo;
                                    entityDet.ModificadoPor = entity.ModificadoPor;
                                    entityDet.FechaModificado = DateTimeOffset.Now;
                                    context.SaveChanges();
                                    break;
                                }
                        }
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateComprobantesContab", ex.Message, null);
                throw;
            }
        }

        public void Anular(int IdComprobante, string ModificadoPor)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    Comprobante ob = context.Comprobantes.Find(IdComprobante);
                    ob.ModificadoPor = ModificadoPor;
                    ob.Estado = Constantes.EstadoInactivo;
                    ob.FechaModificado = DateTimeOffset.Now;
                    context.SaveChanges();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateComprobantesContab", ex.Message, null);
                throw;
            }
        }
    }
}
