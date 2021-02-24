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
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadBusiness _Business;

        public CiudadController(ICiudadBusiness business)
        {
            _Business = business;
        }
        /*
        [HttpGet("{id}")]
        public IActionResult GetCiudades(int id)
        {
            try
            {
                return Ok(_Business.GetCiudades(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateCiudad([FromBody] Ciudad entity)
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
        public IActionResult UpdateCiudad(int id, [FromBody] Ciudad entity)
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
        */
    }
}