using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class PlazoPagoController : ControllerBase
    {
        private readonly IPlazoPagoBusiness plazoPagoBusiness;

        public PlazoPagoController(IPlazoPagoBusiness _plazoPagoBusiness)
        {
            this.plazoPagoBusiness = _plazoPagoBusiness;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = plazoPagoBusiness.GetPlazosPagos(IdEmp);
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
                plazoPagoBusiness.Create(entity);
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
                plazoPagoBusiness.Update(IdPlazo, entity);
                return Ok("Ok");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}