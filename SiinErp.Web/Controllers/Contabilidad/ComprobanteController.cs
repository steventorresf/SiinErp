using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.Contabilidad
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteBusiness _Business;

        public ComprobanteController(IComprobanteBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}/{fechaInicial}/{fechaFinal}")]
        public IActionResult GetAll(int id, string fechaInicial, string fechaFinal)
        {
            try
            {
                return Ok(_Business.GetAll(id, fechaInicial, fechaFinal));
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
                _Business.Create(data);
                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] JObject data)
        {
            try
            {
                _Business.Update(id, data);
                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}/{modificadoPor}")]
        public IActionResult Anular(int id, string modificadoPor)
        {
            try
            {
                _Business.Anular(id, modificadoPor);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}