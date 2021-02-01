using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Cartera.Abstract;
using SiinErp.Areas.Cartera.Business;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class PlazoPagoController : ControllerBase
    {
        private readonly IPlazoPagoBusiness BusinessPlazo;

        public PlazoPagoController()
        {
            BusinessPlazo = new PlazoPagoBusiness();
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