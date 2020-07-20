using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Cartera.Business;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class MovimientosController : ControllerBase
    {
        private MovimientosBusiness BusinessMov = new MovimientosBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Movimientos entity = data["entity"].ToObject<Movimientos>();
                List<FacturasVen> listDetalleFac = data["listDetalleFac"].ToObject<List<FacturasVen>>();

                BusinessMov.Create(entity, listDetalleFac);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}