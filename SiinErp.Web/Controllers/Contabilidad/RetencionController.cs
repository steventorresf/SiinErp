using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Entities.Contabilidad;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.Contabilidad
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class RetencionController : ControllerBase
    {
        private readonly IRetencionBusiness _Business;

        public RetencionController(IRetencionBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetTiposDoc(int id)
        {
            try
            {
                return Ok(_Business.GetRetenciones(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Get/{id}/{tipoDoc}")]
        public IActionResult GetTipoDoc(int id, string tipoDoc)
        {
            try
            {
                return Ok(_Business.GetTipoRet(id, tipoDoc));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Retencion entity)
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
        public IActionResult Update(int id, [FromBody] Retencion entity)
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