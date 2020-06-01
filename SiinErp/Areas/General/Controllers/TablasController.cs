using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;
using SiinErp.Models.General.Entities;

namespace SiinErp.Areas.General.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablasController : ControllerBase
    {
        private TablasBusiness BusinessTab = new TablasBusiness();

        [HttpGet]
        public IActionResult GetTablas(string CodTab)
        {
            try
            {
                var lista = BusinessTab.GetTablas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTabla([FromBody] Tablas entity)
        {
            try
            {
                BusinessTab.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{CodTab}")]
        public IActionResult UpdateTabla(string CodTab, [FromBody] Tablas entity)
        {
            try
            {
                BusinessTab.Update(CodTab, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}