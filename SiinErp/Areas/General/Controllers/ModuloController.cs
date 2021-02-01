using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloBusiness moduloBusiness;

        public ModuloController()
        {
            moduloBusiness = new ModuloBusiness();
        }

        [HttpGet]
        public IActionResult GetModulos()
        {
            try
            {
                var lista = moduloBusiness.GetModulos();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Per")]
        public IActionResult GetModulosPer()
        {
            try
            {
                var lista = moduloBusiness.GetModulosPer();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}