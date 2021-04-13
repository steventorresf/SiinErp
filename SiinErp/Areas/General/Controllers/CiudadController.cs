using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadBusiness ciudadBusiness;

        public CiudadController(ICiudadBusiness _ciudadBusiness)
        {
            this.ciudadBusiness = _ciudadBusiness;
        }

        [HttpGet("{IdDep}")]
        public IActionResult GetCiudades(int IdDep)
        {
            try
            {
                var lista = ciudadBusiness.GetByIdDepartamento(IdDep);
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
