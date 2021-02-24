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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoBusiness _Business;

        public DepartamentoController(IDepartamentoBusiness business)
        {
            _Business = business;
        }

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            try
            {
                return Ok(_Business.GetDepartamentos());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateDepartamento([FromBody] Departamento entity)
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
        public IActionResult UpdateDepartamento(int id, [FromBody] Departamento entity)
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