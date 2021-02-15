using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoBusiness _Business;

        public PeriodoController(IPeriodoBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetPeriodos(int id)
        {
            try
            {
                return Ok(_Business.GetPeriodos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetSig/{id}/{modulo}")]
        public IActionResult GetSiguientePeriodo(int id, string modulo)
        {
            try
            {
                return Ok(_Business.GetSiguientePeriodo(id, modulo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Periodo entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Periodo entity)
        {
            try
            {
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}