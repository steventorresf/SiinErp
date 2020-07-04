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
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientosController : ControllerBase
    {
        private MovimientosBusiness BusinessMov = new MovimientosBusiness();

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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}