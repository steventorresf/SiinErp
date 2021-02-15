using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.Cartera
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class PlazoPagoController : ControllerBase
    {
        private readonly IPlazoPagoBusiness BusinessPlazo;

        public PlazoPagoController(IPlazoPagoBusiness businessPlazo)
        {
            BusinessPlazo = businessPlazo;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = BusinessPlazo.GetPlazosPagos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlazoPago entity)
        {
            try
            {
                BusinessPlazo.Create(entity);
                return Ok("Ok");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPlazo}")]
        public IActionResult Update(int IdPlazo, [FromBody] PlazoPago entity)
        {
            try
            {
                BusinessPlazo.Update(IdPlazo, entity);
                return Ok("Ok");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}