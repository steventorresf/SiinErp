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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaBusiness empresaBusiness;

        public EmpresaController(IEmpresaBusiness _empresaBusiness)
        {
            this.empresaBusiness = _empresaBusiness;
        }

        [HttpGet]
        public IActionResult GetEmpresas()
        {
            try
            {
                var lista = empresaBusiness.GetEmpresas();
                return Ok(lista);
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
                var lista = empresaBusiness.GetEmpresasAct();
                return Ok(lista);
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
                empresaBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdEmp}")]
        public IActionResult UpdateEmpresa(int IdEmp, [FromBody] Empresa entity)
        {
            try
            {
                empresaBusiness.Update(IdEmp, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
