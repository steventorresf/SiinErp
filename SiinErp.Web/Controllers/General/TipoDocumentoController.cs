using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoBusiness _Business;

        public TipoDocumentoController(ITipoDocumentoBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetTiposDocumentos(int id)
        {
            try
            {
                return Ok(_Business.GetTiposDocumentos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{id}/{codigo}")]
        public IActionResult GetByTipoDocumento(int id, string codigo)
        {
            try
            {
                return Ok(_Business.GetTipoDocumento(id, codigo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCodMod/{id}/{modulo}")]
        public IActionResult GetTipoDocumento(int id, string modulo)
        {
            try
            {
                return Ok(_Business.GetTiposDocumentosByModulo(id, modulo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTipoDocumento([FromBody] TipoDocumento entity)
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
        public IActionResult UpdateTipoDocumento(int id, [FromBody] TipoDocumento entity)
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