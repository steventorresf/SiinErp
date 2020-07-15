using SiinErp.Models;
using SiinErp.Areas.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Business;

namespace SiinErp.Areas.Inventario.Business
{
    public class ArticulosBusiness
    {
        public List<Articulos> GetArticulos(int IdEmp)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Articulos> Lista = (from ar in context.Articulos.Where(x => x.IdEmpresa == IdEmp)
                                         join ta in context.TablasEmpresaDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                         join um in context.TablasEmpresaDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                         select new Articulos()
                                         {
                                             IdArticulo = ar.IdArticulo,
                                             IdEmpresa = ar.IdEmpresa,
                                             CodArticulo = ar.CodArticulo,
                                             Referencia = ar.Referencia,
                                             NombreArticulo = ar.NombreArticulo,
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
                                             IdUsuario = ar.IdUsuario,
                                             Estado = ar.Estado,
                                             NombreTipoArticulo = ta.Descripcion,
                                             NombreUnidadMed = um.Descripcion,
                                             DescEsLinea = ar.EsLinea ? "Si" : "No",
                                         }).OrderBy(x => x.NombreArticulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetArticulos", ex.Message, null);
                throw;
            }
        }

        public List<Articulos> GetArticulosByIdListaPrecio(int IdListaPrecio)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Articulos> Lista = (from lp in context.ListaPreciosDetalles.Where(x => x.IdListaPrecio == IdListaPrecio)
                                         join ar in context.Articulos on lp.IdArticulo equals ar.IdArticulo
                                         join ta in context.TablasEmpresaDetalles on ar.IdDetTipoArticulo equals ta.IdDetalle
                                         join um in context.TablasEmpresaDetalles on ar.IdDetUnidadMed equals um.IdDetalle
                                         select new Articulos()
                                         {
                                             IdArticulo = ar.IdArticulo,
                                             IdEmpresa = ar.IdEmpresa,
                                             CodArticulo = ar.CodArticulo,
                                             Referencia = ar.Referencia,
                                             NombreArticulo = ar.NombreArticulo,
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
                                             IdUsuario = ar.IdUsuario,
                                             Estado = ar.Estado,
                                             NombreTipoArticulo = ta.Descripcion,
                                             NombreUnidadMed = um.Descripcion,
                                             DescEsLinea = ar.EsLinea ? "Si" : "No",
                                         }).OrderBy(x => x.NombreArticulo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetArticulosByIdListaPrecio", ex.Message, null);
                throw;
            }
        }

        public List<Articulos> GetArticulosByPrefix(int IdEmp, string Prefix)
        {
            try
            {
                string[] ListPrefix = Prefix.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                SiinErpContext context = new SiinErpContext();
                List<Articulos> Lista = context.Articulos.Where(x => x.IdEmpresa == IdEmp && x.NombreBusqueda.Contains(ListPrefix[0])).ToList();
                for(int i = 1; i < ListPrefix.Length; i++)
                {
                    Lista = Lista.Where(x => x.NombreBusqueda.Contains(ListPrefix[i])).ToList();
                }
                return Lista.OrderBy(x => x.NombreArticulo).ToList();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetArticulosByPrefix", ex.Message, null);
                throw;
            }
        }

        public void Create(Articulos entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Articulos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateArticulo", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdArticulo, Articulos entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Articulos ob = context.Articulos.Find(IdArticulo);
                ob.CodArticulo = entity.CodArticulo;
                ob.Referencia = entity.Referencia;
                ob.NombreArticulo = entity.NombreArticulo;
                ob.IdDetTipoArticulo = entity.IdDetTipoArticulo;
                ob.IdDetUnidadMed = entity.IdDetUnidadMed;
                ob.EsLinea = entity.EsLinea;
                ob.Peso = entity.Peso;
                ob.PcIva = entity.PcIva;
                ob.StkMin = entity.StkMin;
                ob.StkMax = entity.StkMax;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateArticulo", ex.Message, null);
                throw;
            }
        }
    }
}
