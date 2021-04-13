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
    public class ParametroController : ControllerBase
    {
        private readonly IParametroBusiness parametroBusiness;

        public ParametroController(IParametroBusiness _parametroBusiness)
        {
            this.parametroBusiness = _parametroBusiness;
        }

        [HttpGet]
        public IActionResult GetParametros()
        {
            try
            {
                var lista = parametroBusiness.GetParametros();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Parametro entity)
        {
            try
            {
                parametroBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPar}")]
        public IActionResult Update(int IdPar, [FromBody] Parametro entity)
        {
            try
            {
                parametroBusiness.Update(IdPar, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
