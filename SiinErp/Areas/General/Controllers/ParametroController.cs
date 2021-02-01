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
    public class ParametroController : ControllerBase
    {
        private readonly IParametroBusiness parametroBusiness;

        public ParametroController()
        {
            parametroBusiness = new ParametroBusiness();
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