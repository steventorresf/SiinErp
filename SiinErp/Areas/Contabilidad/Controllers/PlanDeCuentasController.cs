using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Business;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class PlanDeCuentasController : ControllerBase
    {
        private PlanDeCuentasBusiness BusinessPlanDeCuentas = new PlanDeCuentasBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTiposDoc(int IdEmp)
        {
            try
            {
                var lista = BusinessPlanDeCuentas.GetPlanDeCuentas(IdEmp);
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
                var entity = BusinessPlanDeCuentas.GetCuenta(IdEmp, CodCuenta);
                return Ok(entity); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlanDeCuentas entity)
        {
            try
            {
                BusinessPlanDeCuentas.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCuentaContable}")]
        public IActionResult Update(int IdCuentaContable, [FromBody] PlanDeCuentas entity)
        {
            try
            {
                BusinessPlanDeCuentas.Update(IdCuentaContable, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}