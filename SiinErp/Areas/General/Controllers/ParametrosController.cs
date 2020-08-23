using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class ParametrosController : ControllerBase
    {
        private ParametrosBusiness BusinessPar = new ParametrosBusiness();

        [HttpGet]
        public IActionResult GetParametros()
        {
            try
            {
                var lista = BusinessPar.GetParametros();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Parametros entity)
        {
            try
            {
                BusinessPar.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPar}")]
        public IActionResult Update(int IdPar, [FromBody] Parametros entity)
        {
            try
            {
                BusinessPar.Update(IdPar, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}