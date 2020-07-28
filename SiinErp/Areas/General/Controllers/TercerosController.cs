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
    public class TercerosController : ControllerBase
    {
        private TercerosBusiness BusinessTer = new TercerosBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTerceros(int IdEmp)
        {
            try
            {
                var lista = BusinessTer.GetTerceros(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByAct/{IdEmp}")]
        public IActionResult GetTercerosActivos(int IdEmp)
        {
            try
            {
                var lista = BusinessTer.GetTercerosActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTercero([FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdTer}")]
        public IActionResult UpdateTercero(int IdTer, [FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.Update(IdTer, entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}