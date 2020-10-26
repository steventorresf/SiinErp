using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Business;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobantesController : ControllerBase
    {
        private ComprobantesBusiness Business = new ComprobantesBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Business.Create(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}