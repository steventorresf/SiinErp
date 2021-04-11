using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Entities.Compras;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;

namespace SiinErp.Web.Controllers.Inventario
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoBusiness _Business;

        public MovimientoController(IMovimientoBusiness business)
        {
            _Business = business;
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();
                _Business.Create(entityMov, listDetalleMov);
                return Ok(entityMov);
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
                _Business.CreateByEntradaCompra(entityOrd, entityMov, listDetalleMov);
                return Ok(entityOrd);
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
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();
                List<MovimientoFormaPago> listDetallePag = data["listDetallePag"].ToObject<List<MovimientoFormaPago>>();
                int id = _Business.CreateByPuntoDeVenta(data);
                return Ok(id);
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
                Movimiento entityMov = data["entityMov"].ToObject<Movimiento>();
                List<MovimientoDetalle> listDetalleMov = data["listDetalleMov"].ToObject<List<MovimientoDetalle>>();
                _Business.CreateByFacturaDeVenta(data);
                return Ok(entityMov);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByModificable/{id}")]
        public IActionResult GetByModificable(int id)
        {
            try
            {
                return Ok(_Business.GetMovimientosByModificable(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{empresa}/{modulo}/{fechaInicial}/{fechaFinal}")]
        public IActionResult GetAll(int empresa, string modulo, string fechaInicial, string fechaFinal)
        {
            try
            {
                return Ok(_Business.GetAll(empresa, modulo, Convert.ToDateTime(fechaInicial), Convert.ToDateTime(fechaFinal)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Facturas
        [HttpGet("Pendientes/{empresa}/{tercero}")]
        public IActionResult GetPendientesByTercero(int empresa, int tercero)
        {
            try
            {
                return Ok(_Business.GetPendientesByTercero(empresa, tercero));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByFecha/{empresa}/{fechaInicial}/{fechaFinal}")]
        public IActionResult GetFacturasByFecha(int empresa, string fechaInicial, string fechaFinal)
        {
            try
            {
                return Ok(_Business.GetFacturasByRangoFecha(empresa, Convert.ToDateTime(fechaInicial), Convert.ToDateTime(fechaFinal)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFactura(int id, [FromBody] Movimiento entity)
        {
            try
            {
                _Business.UpdateFactura(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Anular(int id)
        {
            try
            {
                _Business.Anular(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("LastAlm/{usuario}/{empresa}")]
        public IActionResult GetLastAlmacenByUsu(string usuario, int empresa)
        {
            try
            {
                int IdDetAlmacen = 0;//_Business.GetLastAlmacenByUsu(usuario, empresa);
                return Ok(IdDetAlmacen);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Impresion
        [HttpGet("Imp/{id}")]
        public IActionResult Imprimir(int id)
        {
            try
            {
                return Ok(_Business.Imprimir(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}