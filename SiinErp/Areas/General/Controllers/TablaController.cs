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
    public class TablaController : ControllerBase
    {
        private readonly ITablaBusiness tablaBusiness;

        public TablaController(ITablaBusiness _tablaBusiness)
        {
            this.tablaBusiness = _tablaBusiness;
        }

        [HttpGet]
        public IActionResult GetTablasVisible()
        {
            try
            {
                var lista = tablaBusiness.GetTablasVisible();
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
