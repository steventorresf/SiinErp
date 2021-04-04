using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Inventario
{
    public class ArticuloBusiness : IArticuloBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public ArticuloBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<Articulo> GetArticulos(int IdEmp)
        {
            try
            {
                List<Articulo> Lista = (from ar in context.Articulos.Where(x => x.IdEmpresa == IdEmp)
                                        join ta in context.TablasDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                        join um in context.TablasDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                        select new Articulo()
                                        {
                                            IdArticulo = ar.IdArticulo,
                                            IdEmpresa = ar.IdEmpresa,
                                            CodArticulo = ar.CodArticulo,
                                            Referencia = ar.Referencia,
                                            NombreArticulo = ar.NombreArticulo,
                                            NombreBusqueda = ar.NombreBusqueda,
                                            IdDetTipoArticulo = ar.IdDetTipoArticulo,
                                            IdDetUnidadMed = ar.IdDetUnidadMed,
                                            EsLinea = ar.EsLinea,
                                            Peso = ar.Peso,
                                            IncluyeIva = ar.IncluyeIva,
                                            PcIva = ar.PcIva,
                                            StkMin = ar.StkMin,
                                            StkMax = ar.StkMax,
                                            VrVenta = ar.VrVenta,
                                            VrCosto = ar.VrCosto,
                                            Existencia = ar.Existencia,
                                            IndCosto = ar.IndCosto,
                                            IndConsumo = ar.IndConsumo,
                                            AfectaInventario = ar.AfectaInventario,
                                            FechaCreacion = ar.FechaCreacion,
                                            FechaUEntrada = ar.FechaUEntrada,
                                            FechaUPedida = ar.FechaUPedida,
                                            FechaUSalida = ar.FechaUSalida,
                                            CreadoPor = ar.CreadoPor,
                                            EstadoFila = ar.EstadoFila,
                                            NombreTipoArticulo = ta.Descripcion,
                                            NombreUnidadMed = um.Descripcion,
                                            DescEsLinea = ar.EsLinea ? "Si" : "No",
                                        }).OrderBy(x => x.NombreArticulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetArticulos", ex.Message, null);
                throw;
            }
        }

        public List<Articulo> GetArticulosByIdListaPrecio(int IdListaPrecio)
        {
            try
            {
                List<Articulo> Lista = (from lp in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                        join ar in context.Articulos on lp.IdArticulo equals ar.IdArticulo
                                        join ta in context.TablasDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                        join um in context.TablasDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                        select new Articulo()
                                        {
                                            IdArticulo = ar.IdArticulo,
                                            IdEmpresa = ar.IdEmpresa,
                                            CodArticulo = ar.CodArticulo,
                                            Referencia = ar.Referencia,
                                            NombreArticulo = ar.NombreArticulo,
                                            NombreBusqueda = ar.NombreBusqueda,
                                            IdDetTipoArticulo = ar.IdDetTipoArticulo,
                                            IdDetUnidadMed = ar.IdDetUnidadMed,
                                            EsLinea = ar.EsLinea,
                                            Peso = ar.Peso,
                                            IncluyeIva = ar.IncluyeIva,
                                            PcIva = ar.PcIva,
                                            StkMin = ar.StkMin,
                                            StkMax = ar.StkMax,
                                            VrVenta = ar.VrVenta,
                                            VrCosto = ar.VrCosto,
                                            Existencia = ar.Existencia,
                                            IndCosto = ar.IndCosto,
                                            IndConsumo = ar.IndConsumo,
                                            AfectaInventario = ar.AfectaInventario,
                                            FechaCreacion = ar.FechaCreacion,
                                            FechaUEntrada = ar.FechaUEntrada,
                                            FechaUPedida = ar.FechaUPedida,
                                            FechaUSalida = ar.FechaUSalida,
                                            CreadoPor = ar.CreadoPor,
                                            EstadoFila = ar.EstadoFila,
                                            NombreTipoArticulo = ta.Descripcion,
                                            NombreUnidadMed = um.Descripcion,
                                            DescEsLinea = ar.EsLinea ? "Si" : "No",
                                        }).OrderBy(x => x.NombreArticulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetArticulosByIdListaPrecio", ex.Message, null);
                throw;
            }
        }

        public Articulo GetByCodigoListaP(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                int IdListaPrecio = data["idListaPrecio"].ToObject<int>();
                string Codigo = data["codigo"].ToObject<string>();
                Articulo entity = (from lp in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                   join ar in context.Articulos on lp.IdArticulo equals ar.IdArticulo
                                   join ta in context.TablasDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                   join um in context.TablasDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                   where ar.CodArticulo.Equals(Codigo)
                                   select new Articulo()
                                   {
                                       IdArticulo = ar.IdArticulo,
                                       IdEmpresa = ar.IdEmpresa,
                                       CodArticulo = ar.CodArticulo,
                                       Referencia = ar.Referencia,
                                       NombreArticulo = ar.NombreArticulo,
                                       NombreBusqueda = ar.NombreBusqueda,
                                       IdDetTipoArticulo = ar.IdDetTipoArticulo,
                                       IdDetUnidadMed = ar.IdDetUnidadMed,
                                       EsLinea = ar.EsLinea,
                                       Peso = ar.Peso,
                                       IncluyeIva = ar.IncluyeIva,
                                       PcIva = ar.PcIva,
                                       StkMin = ar.StkMin,
                                       StkMax = ar.StkMax,
                                       VrVenta = ar.VrVenta,
                                       VrCosto = ar.VrCosto,
                                       Existencia = ar.Existencia,
                                       IndCosto = ar.IndCosto,
                                       IndConsumo = ar.IndConsumo,
                                       AfectaInventario = ar.AfectaInventario,
                                       FechaCreacion = ar.FechaCreacion,
                                       FechaUEntrada = ar.FechaUEntrada,
                                       FechaUPedida = ar.FechaUPedida,
                                       FechaUSalida = ar.FechaUSalida,
                                       CreadoPor = ar.CreadoPor,
                                       EstadoFila = ar.EstadoFila,
                                       NombreTipoArticulo = ta.Descripcion,
                                       NombreUnidadMed = um.Descripcion,
                                       DescEsLinea = ar.EsLinea ? "Si" : "No",
                                   }).FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByCodigoListaP", ex.Message, null);
                throw;
            }
        }

        public List<Articulo> GetByPrefixListaP(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                int IdListaPrecio = data["idListaPrecio"].ToObject<int>();
                string Prefix = data["prefix"].ToObject<string>();
                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Articulo> Lista = (from lp in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                        join ar in context.Articulos on lp.IdArticulo equals ar.IdArticulo
                                        join ta in context.TablasDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                        join um in context.TablasDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                        where ar.NombreBusqueda.Contains(ListPrefix[0])
                                        select new Articulo()
                                        {
                                            IdArticulo = ar.IdArticulo,
                                            IdEmpresa = ar.IdEmpresa,
                                            CodArticulo = ar.CodArticulo,
                                            Referencia = ar.Referencia,
                                            NombreArticulo = ar.NombreArticulo,
                                            NombreBusqueda = ar.NombreBusqueda,
                                            IdDetTipoArticulo = ar.IdDetTipoArticulo,
                                            IdDetUnidadMed = ar.IdDetUnidadMed,
                                            EsLinea = ar.EsLinea,
                                            Peso = ar.Peso,
                                            IncluyeIva = ar.IncluyeIva,
                                            PcIva = ar.PcIva,
                                            StkMin = ar.StkMin,
                                            StkMax = ar.StkMax,
                                            VrVenta = ar.VrVenta,
                                            VrCosto = ar.VrCosto,
                                            Existencia = ar.Existencia,
                                            IndCosto = ar.IndCosto,
                                            IndConsumo = ar.IndConsumo,
                                            AfectaInventario = ar.AfectaInventario,
                                            FechaCreacion = ar.FechaCreacion,
                                            FechaUEntrada = ar.FechaUEntrada,
                                            FechaUPedida = ar.FechaUPedida,
                                            FechaUSalida = ar.FechaUSalida,
                                            CreadoPor = ar.CreadoPor,
                                            EstadoFila = ar.EstadoFila,
                                            NombreTipoArticulo = ta.Descripcion,
                                            NombreUnidadMed = um.Descripcion,
                                            DescEsLinea = ar.EsLinea ? "Si" : "No",
                                        }).ToList();

                for (int i = 1; i < ListPrefix.Length; i++)
                {
                    Lista = Lista.Where(x => x.NombreBusqueda.Contains(ListPrefix[i])).ToList();
                }
                return Lista.OrderBy(x => x.NombreArticulo).ToList();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByPrefixListaP", ex.Message, null);
                throw;
            }
        }

        public List<Articulo> GetArticulosByAlmacenPrefix(int IdDetAlm, int IdEmp, string Prefix)
        {
            try
            {
                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Articulo> Lista = (from ex in context.Existencias.Where(x => x.IdDetAlmacen == IdDetAlm)
                                        join ar in context.Articulos on ex.IdArticulo equals ar.IdArticulo
                                        where ar.NombreBusqueda.Contains(ListPrefix[0])
                                        select ar).ToList();

                for (int i = 1; i < ListPrefix.Length; i++)
                {
                    Lista = Lista.Where(x => x.NombreBusqueda.Contains(ListPrefix[i])).ToList();
                }
                return Lista.OrderBy(x => x.NombreArticulo).ToList();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetArticulosByAlmacenPrefix", ex.Message, null);
                throw;
            }
        }

        public void Create(Articulo entity)
        {
            try
            {
                entity.NombreBusqueda = entity.CodArticulo + " - " + entity.NombreArticulo;
                entity.FechaCreacion = DateTimeOffset.Now;
                entity.FechaModificado = DateTimeOffset.Now;
                context.Articulos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateArticulo", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdArticulo, Articulo entity)
        {
            try
            {
                Articulo ob = context.Articulos.Find(IdArticulo);
                ob.CodArticulo = entity.CodArticulo;
                ob.Referencia = entity.Referencia;
                ob.NombreArticulo = entity.NombreArticulo;
                ob.NombreBusqueda = entity.CodArticulo + " - " + entity.NombreArticulo;
                ob.IdDetTipoArticulo = entity.IdDetTipoArticulo;
                ob.IdDetUnidadMed = entity.IdDetUnidadMed;
                ob.EsLinea = entity.EsLinea;
                ob.VrCosto = entity.VrCosto;
                ob.VrVenta = entity.VrVenta;
                ob.Peso = entity.Peso;
                ob.IncluyeIva = entity.IncluyeIva;
                ob.PcIva = entity.PcIva;
                ob.StkMin = entity.StkMin;
                ob.StkMax = entity.StkMax;
                ob.EstadoFila = entity.EstadoFila;
                ob.AfectaInventario = entity.AfectaInventario;
                ob.ModificadoPor = entity.ModificadoPor;
                ob.FechaModificado = DateTimeOffset.Now;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateArticulo", ex.Message, null);
                throw;
            }
        }
    }
}