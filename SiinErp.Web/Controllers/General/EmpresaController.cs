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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaBusiness _Business;

        public EmpresaController(IEmpresaBusiness business)
        {
            _Business = business;
        }

        [HttpGet]
        public IActionResult GetEmpresas()
        {
            try
            {
                return Ok(_Business.GetEmpresas());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Act")]
        public IActionResult GetEmpresasAct()
        {
            try
            {
                return Ok(_Business.GetEmpresasAct());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateEmpresa([FromBody] Empresa entity)
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
        public IActionResult UpdateEmpresa(int id, [FromBody] Empresa entity)
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