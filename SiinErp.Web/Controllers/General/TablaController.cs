using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TablaController : ControllerBase
    {
        private readonly ITablaBusiness _Business;

        public TablaController(ITablaBusiness business)
        {
            _Business = business;
        }

        [HttpGet]
        public IActionResult GetTablas()
        {
            try
            {
                return Ok(_Business.GetTablas());
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
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTabla(int id, [FromBody] Tabla entity)
        {
            try
            {
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}