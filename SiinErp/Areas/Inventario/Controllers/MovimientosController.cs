using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientosController : ControllerBase
    {
        private MovimientosBusiness BusinessMov = new MovimientosBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Movimientos entityMov = data["entityMov"].ToObject<Movimientos>();
                List<MovimientosDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientosDetalle>>();

                BusinessMov.Create(entityMov, listDetalleMov);
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
                string numFactura = data["numFactura"].ToObject<string>();
                Ordenes entityOrd = data["entityOrd"].ToObject<Ordenes>();
                Movimientos entityMov = data["entityMov"].ToObject<Movimientos>();
                List<MovimientosDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientosDetalle>>();

                BusinessMov.CreateByEntradaCompra(numFactura, entityOrd, entityMov, listDetalleMov);
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
                Movimientos entityMov = data["entityMov"].ToObject<Movimientos>();
                List<MovimientosDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientosDetalle>>();
                List<MovimientosFormasPago> listDetallePag = data["listDetallePag"].ToObject<List<MovimientosFormasPago>>();

                BusinessMov.CreateByPuntoDeVenta(entityMov, listDetalleMov, listDetallePag);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByFacturaDeVenta")]
        public IActionResult CreateByFacturaDeVenta([FromBody] JObject data)
        {
            try
            {
                Movimientos entityMov = data["entityMov"].ToObject<Movimientos>();
                List<MovimientosDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientosDetalle>>();

                BusinessMov.CreateByFacturaDeVenta(entityMov, listDetalleMov);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByModificable/{Fecha}")]
        public IActionResult GetByModificable(DateTime Fecha)
        {
            try
            {
                var lista = BusinessMov.GetMovimientosByModificable(Fecha);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Facturas
        [HttpGet("PenCli/{IdCli}")]
        public IActionResult GetPendientesByCli(int IdCli)
        {
            try
            {
                var lista = BusinessMov.GetPendientesByCli(IdCli);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByFecha/{IdEmp}/{Fecha}")]
        public IActionResult GetFacturasByFecha(int IdEmp, string Fecha)
        {
            try
            {
                var lista = BusinessMov.GetFacturasByFecha(IdEmp, DateTimeOffset.Parse(Fecha));
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdFac}")]
        public IActionResult UpdateFactura(int IdFac, [FromBody] Movimientos entity)
        {
            try
            {
                BusinessMov.UpdateFactura(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{IdFac}")]
        public IActionResult AnularFactura(int IdFac)
        {
            try
            {
                BusinessMov.AnularFactura(IdFac);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}