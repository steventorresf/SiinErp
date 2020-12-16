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
            catch (Exception)
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
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTab}")]
        public IActionResult UpdateTabla(int IdTab, [FromBody] Tablas entity)
        {
            try
            {
                BusinessTab.Update(IdTab, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}