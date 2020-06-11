using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;
using SiinErp.Models.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class CiudadesController : ControllerBase
    {
        private CiudadesBusiness BusinessCiu = new CiudadesBusiness();

        [HttpGet("{IdDep}")]
        public IActionResult GetCiudades(int IdDep)
        {
            try
            {
                var lista = BusinessCiu.GetCiudades(IdDep);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateCiudad([FromBody] Ciudades entity)
        {
            try
            {
                BusinessCiu.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdCiu}")]
        public IActionResult UpdateCiudad(int IdCiu, [FromBody] Ciudades entity)
        {
            try
            {
                BusinessCiu.Update(IdCiu, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}