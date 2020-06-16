using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class PeriodosController : ControllerBase
    {
        private PeriodosBusiness BusinessPer = new PeriodosBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetPeriodos(int IdEmp)
        {
            try
            {
                var lista = BusinessPer.GetPeriodos(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetSig/{IdEmp}/{CodMod}")]
        public IActionResult GetSiguientePeriodo(int IdEmp, string CodMod)
        {
            try
            {
                var periodo = BusinessPer.GetSiguientePeriodo(IdEmp, CodMod);
                return Ok(periodo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Periodos entity)
        {
            try
            {
                BusinessPer.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdPer}")]
        public IActionResult Update(int IdPer, [FromBody] Periodos entity)
        {
            try
            {
                BusinessPer.Update(IdPer, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}