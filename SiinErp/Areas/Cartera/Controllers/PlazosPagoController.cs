using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Cartera.Business;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class PlazosPagoController : ControllerBase
    {
        private PlazosPagoBusiness BusinessPlazo = new PlazosPagoBusiness();

        [HttpGet]
        public IActionResult Get(int IdDep)
        {
            try
            {
                var lista = BusinessPlazo.GetPlazosPagos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlazosPago entity)
        {
            try
            {
                BusinessPlazo.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdPlazo}")]
        public IActionResult Update(int IdPlazo, [FromBody] PlazosPago entity)
        {
            try
            {
                BusinessPlazo.Update(IdPlazo, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}