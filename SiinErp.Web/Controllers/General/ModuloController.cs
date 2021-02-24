using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloBusiness _Business;

        public ModuloController(IModuloBusiness business)
        {
            _Business = business;
        }

        [HttpGet]
        public IActionResult GetModulos()
        {
            try
            {
                return Ok(_Business.GetModulos());
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
                return Ok(_Business.GetModulosPer());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}