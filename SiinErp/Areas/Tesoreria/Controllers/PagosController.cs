using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Tesoreria.Business;

using SiinErp.Utiles;

namespace SiinErp.Areas.Tesoreria.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Tesoreria)]
    public class PagosController : ControllerBase
    {
        private PagosBusiness BusinessMov = new PagosBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Pagos entity = data["entity"].ToObject<Pagos>();
                List<PagosDetalle> listDetalleFac = data["listDetalleFac"].ToObject<List<PagosDetalle>>();

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