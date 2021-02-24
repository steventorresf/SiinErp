using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Entities.Contabilidad;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Contabilidad
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class PlanDeCuentaController : ControllerBase
    {
        private readonly IPlanDeCuentaBusiness _Business;

        public PlanDeCuentaController(IPlanDeCuentaBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                return Ok(_Business.GetPlanDeCuentas(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByNivel/{id}/{nivel}")]
        public IActionResult GetAllByNivel(int id, string nivel)
        {
            try
            {
                return Ok(_Business.GetPlanDeCuentasByNivel(id, nivel));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Get/{id}/{cuenta}")]
        public IActionResult GetTipoDoc(int id, string cuenta)
        {
            try
            {
                return Ok(_Business.GetCuenta(id, cuenta));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlanDeCuenta entity)
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
        public IActionResult Update(int id, [FromBody] PlanDeCuenta entity)
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