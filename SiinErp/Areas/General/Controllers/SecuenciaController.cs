using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class SecuenciaController : ControllerBase
    {
        private readonly ISecuenciaBusiness secuenciaBusiness;

        public SecuenciaController()
        {
            secuenciaBusiness = new SecuenciaBusiness();
        }


        [HttpGet("GetSec/{Pre}/{IdEmp}")]
        public IActionResult GetCiudades(string Pre, int IdEmp)
        {
            try
            {
                string strSecuencia = secuenciaBusiness.GetPrefijoSecuencia(Pre, IdEmp);
                return Ok(strSecuencia);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
