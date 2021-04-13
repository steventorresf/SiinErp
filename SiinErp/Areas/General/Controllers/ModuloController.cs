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
    public class ModuloController : ControllerBase
    {
        private readonly IModuloBusiness moduloBusiness;

        public ModuloController(IModuloBusiness _moduloBusiness)
        {
            this.moduloBusiness = _moduloBusiness;
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
