using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Entities.Contabilidad;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class PlanDeCuentaController : ControllerBase
    {
        private readonly IPlanDeCuentaBusiness planDeCuentaBusiness;

        public PlanDeCuentaController(IPlanDeCuentaBusiness _planDeCuentaBusiness)
        {
            this.planDeCuentaBusiness = _planDeCuentaBusiness;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult GetAll(int IdEmp)
        {
            try
            {
                var lista = planDeCuentaBusiness.GetPlanDeCuentas(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByNivel/{IdEmp}/{Nivel}")]
        public IActionResult GetAllByNivel(int IdEmp, string Nivel)
        {
            try
            {
                var lista = planDeCuentaBusiness.GetPlanDeCuentasByNivel(IdEmp, Nivel);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Get/{IdEmp}/{CodCuenta}")]
        public IActionResult GetTipoDoc(int IdEmp, string CodCuenta)
        {
            try
            {
                var entity = planDeCuentaBusiness.GetCuenta(IdEmp, CodCuenta);
                return Ok(entity); 
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
                planDeCuentaBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCuentaContable}")]
        public IActionResult Update(int IdCuentaContable, [FromBody] PlanDeCuenta entity)
        {
            try
            {
                planDeCuentaBusiness.Update(IdCuentaContable, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}