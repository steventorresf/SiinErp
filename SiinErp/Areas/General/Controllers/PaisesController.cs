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
    public class PaisesController : ControllerBase
    {
        private PaisesBusiness BusinessPais = new PaisesBusiness();

        [HttpGet]
        public IActionResult GetPaises()
        {
            try
            {
                var lista = BusinessPais.GetPaises();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreatePais([FromBody] Paises entity)
        {
            try
            {
                BusinessPais.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPais}")]
        public IActionResult UpdatePais(int IdPais, [FromBody] Paises entity)
        {
            try
            {
                BusinessPais.Update(IdPais, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}