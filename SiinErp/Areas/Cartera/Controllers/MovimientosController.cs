using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Cartera.Business;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class MovimientosController : ControllerBase
    {
        private MovimientosCarBusiness BusinessMov = new MovimientosCarBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                MovimientosCar entity = data["entity"].ToObject<MovimientosCar>();
                List<Movimientos> listDetalleFac = data["listDetalleFac"].ToObject<List<Movimientos>>();

                BusinessMov.Create(entity, listDetalleFac);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}