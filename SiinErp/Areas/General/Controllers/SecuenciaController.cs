using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
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

        public SecuenciaController(ISecuenciaBusiness _secuenciaBusiness)
        {
            this.secuenciaBusiness = _secuenciaBusiness;
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
