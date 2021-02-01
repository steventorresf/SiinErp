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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoBusiness departamentoBusiness;

        public DepartamentoController()
        {
            departamentoBusiness = new DepartamentoBusiness();
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