using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;

namespace SiinErp.Areas.General.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulosController : ControllerBase
    {
        private ModulosBusiness BusinessMod = new ModulosBusiness();

        [HttpGet]
        public IActionResult GetModulos()
        {
            try
            {
                var lista = BusinessMod.GetModulos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}