using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
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

        [HttpGet("Per")]
        public IActionResult GetModulosPer()
        {
            try
            {
                var lista = BusinessMod.GetModulosPer();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}