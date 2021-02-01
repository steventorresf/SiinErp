using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadBusiness ciudadBusiness;

        public CiudadController()
        {
            ciudadBusiness = new CiudadBusiness();
        }

        [HttpGet("{IdDep}")]
        public IActionResult GetCiudades(int IdDep)
        {
            try
            {
                var lista = ciudadBusiness.GetCiudades(IdDep);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateCiudad([FromBody] Ciudad entity)
        {
            try
            {
                ciudadBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCiu}")]
        public IActionResult UpdateCiudad(int IdCiu, [FromBody] Ciudad entity)
        {
            try
            {
                ciudadBusiness.Update(IdCiu, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}