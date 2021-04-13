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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoBusiness departamentoBusiness;

        public DepartamentoController(IDepartamentoBusiness _departamentoBusiness)
        {
            this.departamentoBusiness = _departamentoBusiness;
        }

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            try
            {
                var lista = departamentoBusiness.GetDepartamentos();
                return Ok(lista);
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
                departamentoBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdDep}")]
        public IActionResult UpdateDepartamento(int IdDep, [FromBody] Departamento entity)
        {
            try
            {
                departamentoBusiness.Update(IdDep, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
