using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Contabilidad.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobantesDetalleController : ControllerBase
    {
        private ComprobantesDetalleBusiness Business = new ComprobantesDetalleBusiness();

        [HttpGet("{IdComp}")]
        public IActionResult GetAll(int IdComp)
        {
            try
            {
                var lista = Business.GetAll(IdComp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}