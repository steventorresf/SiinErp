using SiinErp.Models;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Inventario.Abstract;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.Inventario.Business
{
    public class ArticuloBusiness : IArticuloBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public ArticuloBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Articulo> GetArticulos(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                                             PcIva = ar.PcIva,
                                             StkMin = ar.StkMin,
                                             StkMax = ar.StkMax,
                                             VrVenta = ar.VrVenta,
                                             VrCosto = ar.VrCosto,
                                             Existencia = ar.Existencia,
                                             IndCosto = ar.IndCosto,
                                             IndConsumo = ar.IndConsumo,
                                             FechaCreacion = ar.FechaCreacion,
                                             FechaUEntrada = ar.FechaUEntrada,
                                             FechaUPedida = ar.FechaUPedida,
                                             FechaUSalida = ar.FechaUSalida,
                                             CreadoPor = ar.CreadoPor,
                                             Estado = ar.Estado,
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

        public List<Articulo> GetAllByPrefix(JObject data)
        {
            try
            {
                int IdEmpresa = data["idEmpresa"].ToObject<int>();
                string Prefix = data["prefix"].ToObject<string>();

                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                SiinErpContext context = new SiinErpContext();
                List<Articulo> Lista = (from ar in context.Articulos.Where(x => x.IdEmpresa == IdEmpresa && x.NombreBusqueda.Contains(ListPrefix[0]))
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
                                            PcIva = ar.PcIva,
                                            StkMin = ar.StkMin,
                                            StkMax = ar.StkMax,
                                            VrVenta = ar.VrVenta,
                                            VrCosto = ar.VrCosto,
                                            Existencia = ar.Existencia,
                                            IndCosto = ar.IndCosto,
                                            IndConsumo = ar.IndConsumo,
                                            FechaCreacion = ar.FechaCreacion,
                                            FechaUEntrada = ar.FechaUEntrada,
                                            FechaUPedida = ar.FechaUPedida,
                                            FechaUSalida = ar.FechaUSalida,
                                            CreadoPor = ar.CreadoPor,
                                            Estado = ar.Estado,
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

        public List<Articulo> GetArticulosByIdListaPrecio(int IdListaPrecio)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
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
                                             PcIva = ar.PcIva,
                                             StkMin = ar.StkMin,
                                             StkMax = ar.StkMax,
                                             VrVenta = ar.VrVenta,
                                             VrCosto = ar.VrCosto,
                                             Existencia = ar.Existencia,
                                             IndCosto = ar.IndCosto,
                                             IndConsumo = ar.IndConsumo,
                                             FechaCreacion = ar.FechaCreacion,
                                             FechaUEntrada = ar.FechaUEntrada,
                                             FechaUPedida = ar.FechaUPedida,
                                             FechaUSalida = ar.FechaUSalida,
                                             CreadoPor = ar.CreadoPor,
                                             Estado = ar.Estado,
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

                SiinErpContext context = new SiinErpContext();
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
                                        PcIva = ar.PcIva,
                                        StkMin = ar.StkMin,
                                        StkMax = ar.StkMax,
                                        VrVenta = ar.VrVenta,
                                        VrCosto = ar.VrCosto,
                                        Existencia = ar.Existencia,
                                        IndCosto = ar.IndCosto,
                                        IndConsumo = ar.IndConsumo,
                                        FechaCreacion = ar.FechaCreacion,
                                        FechaUEntrada = ar.FechaUEntrada,
                                        FechaUPedida = ar.FechaUPedida,
                                        FechaUSalida = ar.FechaUSalida,
                                        CreadoPor = ar.CreadoPor,
                                        Estado = ar.Estado,
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

                SiinErpContext context = new SiinErpContext();
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
                                             PcIva = ar.PcIva,
                                             StkMin = ar.StkMin,
                                             StkMax = ar.StkMax,
                                             VrVenta = ar.VrVenta,
                                             VrCosto = ar.VrCosto,
                                             Existencia = ar.Existencia,
                                             IndCosto = ar.IndCosto,
                                             IndConsumo = ar.IndConsumo,
                                             FechaCreacion = ar.FechaCreacion,
                                             FechaUEntrada = ar.FechaUEntrada,
                                             FechaUPedida = ar.FechaUPedida,
                                             FechaUSalida = ar.FechaUSalida,
                                             CreadoPor = ar.CreadoPor,
                                             Estado = ar.Estado,
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

                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                SiinErpContext context = new SiinErpContext();
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
                ob.PcIva = entity.PcIva;
                ob.StkMin = entity.StkMin;
                ob.StkMax = entity.StkMax;
                ob.Estado = entity.Estado;
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
