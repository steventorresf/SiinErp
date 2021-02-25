using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.Inventario.Abstract;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientoController : ControllerBase
    {
        private IMovimientoBusiness movimientoBusiness;
        private ITerceroBusiness terceroBusiness;

        public MovimientoController()
        {
            movimientoBusiness = new MovimientoBusiness();
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();

                movimientoBusiness.Create(entityMov, listDetalleMov);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByEntradaCompra")]
        public IActionResult CreateByEntradaCompra([FromBody] JObject data)
        {
            try
            {
                Orden entityOrd = data["entityOrd"].ToObject<Orden>();
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();

                movimientoBusiness.CreateByEntradaCompra(entityOrd, entityMov, listDetalleMov);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByPuntoDeVenta")]
        public IActionResult CreateByPuntoDeVenta([FromBody] JObject data)
        {
            try
            {
                int id = movimientoBusiness.CreateByPuntoDeVenta(data);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("ByPuntoDeVenta")]
        public IActionResult UpdateByPuntoDeVenta([FromBody] JObject data)
        {
            try
            {
                int id = movimientoBusiness.UpdateByPuntoDeVenta(data);
                return Ok(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("ByFacturaDeVenta")]
        public IActionResult CreateByFacturaDeVenta([FromBody] JObject data)
        {
            try
            {
                movimientoBusiness.CreateByFacturaDeVenta(data);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByDoc")]
        public IActionResult GetByDocumento([FromBody] JObject data)
        {
            try
            {
                var entity = movimientoBusiness.GetByDocumento(data);

                if(entity.IdTercero != null)
                {
                    var listCli = terceroBusiness.GetClienteListById(Convert.ToInt32(entity.IdTercero));
                    return Ok(new { resp = true, entity, listCli });
                }
                else
                {
                    return Ok(new { resp = true, entity });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByModificable/{IdEmp}")]
        public IActionResult GetByModificable(int IdEmp)
        {
            try
            {
                var lista = movimientoBusiness.GetMovimientosByModificable(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                //  errorBusiness.Create("GetConceptos", ex.Message, null);
                throw;
            }
        }

        [HttpGet("{IdEmp}/{Modulo}/{FechaIni}/{FechaFin}")]
        public IActionResult GetAll(int IdEmp, string Modulo,  string FechaIni, string FechaFin)
        {
            try
            {
                var lista = movimientoBusiness.GetAll(IdEmp, Modulo, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }


      
        #region Facturas
        [HttpGet("Pendientes/{IdEmp}/{IdTercero}")]
           public IActionResult GetPendientesByTercero(int IdEmp, int IdTercero)
           {
               try
               {
                   var lista = movimientoBusiness.GetPendientesByTercero(IdEmp, IdTercero);
                   return Ok(lista);
               }
               catch (Exception)
               {
                   throw;
               }
           }  

    

        [HttpGet("ByFecha/{IdEmp}/{FechaIni}/{FechaFin}")]
        public IActionResult GetFacturasByFecha(int IdEmp, string FechaIni, string FechaFin)
        {
            try
            {
                var lista = movimientoBusiness.GetFacturasByRangoFecha(IdEmp, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdFac}")]
        public IActionResult UpdateFactura(int IdFac, [FromBody] Movimiento entity)
        {
            try
            {
                movimientoBusiness.UpdateFactura(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Anular(int Id)
        {
            try
            {
                movimientoBusiness.Anular(Id);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;                
            }
        }

        [HttpGet("LastAlm/{NomUsu}/{IdEmp}")]
        public IActionResult GetLastAlmacenByUsu(string NomUsu, int IdEmp)
        {
            try
            {
                int IdDetAlmacen = movimientoBusiness.getLastAlmacenByUsu(NomUsu, IdEmp);
                return Ok(IdDetAlmacen);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion


        #region Impresion
        [HttpGet("Imp/{IdMov}")]
        public IActionResult Imprimir(int IdMov)
        {
            try
            {
                var entity = movimientoBusiness.Imprimir(IdMov);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}