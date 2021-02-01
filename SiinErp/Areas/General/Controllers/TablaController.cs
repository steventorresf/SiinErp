using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TablaController : ControllerBase
    {
        private readonly ITablaBusiness tablaBusiness;

        public TablaController()
        {
            tablaBusiness = new TablaBusiness();
        }

        [HttpGet]
        public IActionResult GetTablas(string CodTab)
        {
            try
            {
                var lista = tablaBusiness.GetTablas();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTabla([FromBody] Tabla entity)
        {
            try
            {
                tablaBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTab}")]
        public IActionResult UpdateTabla(int IdTab, [FromBody] Tabla entity)
        {
            try
            {
                tablaBusiness.Update(IdTab, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}