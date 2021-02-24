using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Tesoreria;
using SiinErp.Model.Entities.Tesoreria;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;

namespace SiinErp.Web.Controllers.Tesoreria
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Tesoreria)]
    public class PagoController : ControllerBase
    {
        private readonly IPagoBusiness _Business;

        public PagoController(IPagoBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{empresa}/{fechaInicial}/{fechaFinal}")]
        public IActionResult GetAll(int empresa, string fechaInicial, string fechaFinal)
        {
            try
            {
                return Ok(_Business.GetAll(empresa, Convert.ToDateTime(fechaInicial), Convert.ToDateTime(fechaFinal)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Pago entity = data["entity"].ToObject<Pago>();
                List<PagoDetalle> listDetalleFac = data["listDetalleFac"].ToObject<List<PagoDetalle>>();
                _Business.Create(entity, listDetalleFac);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}