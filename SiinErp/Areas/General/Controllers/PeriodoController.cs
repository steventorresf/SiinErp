using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoBusiness periodoBusiness;

        public PeriodoController(IPeriodoBusiness _periodoBusiness)
        {
            this.periodoBusiness = _periodoBusiness;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult GetPeriodos(int IdEmp)
        {
            try
            {
                var lista = periodoBusiness.GetPeriodos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetSig/{IdEmp}/{CodMod}")]
        public IActionResult GetSiguientePeriodo(int IdEmp, string CodMod)
        {
            try
            {
                var periodo = periodoBusiness.GetSiguientePeriodo(IdEmp, CodMod);
                return Ok(periodo);
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
                periodoBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPer}")]
        public IActionResult Update(int IdPer, [FromBody] Periodo entity)
        {
            try
            {
                periodoBusiness.Update(IdPer, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
