using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Compras.Business;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Compras.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Compras)]
    public class OrdenesController : ControllerBase
    {
        private OrdenesBusiness BusinessOrd = new OrdenesBusiness();

        [HttpPost]
        public IActionResult Create([FromBody] Ordenes entity)
        {
            try
            {
                BusinessOrd.Create(entity, null);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}