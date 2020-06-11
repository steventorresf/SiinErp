using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;
using SiinErp.Models.General.Entities;
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
    }
}