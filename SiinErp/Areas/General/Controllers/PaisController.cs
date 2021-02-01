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
    public class PaisController : ControllerBase
    {
        private readonly IPaisBusiness paisBusiness;

        public PaisController()
        {
            paisBusiness = new PaisBusiness();
        }

        [HttpGet]
        public IActionResult GetPaises()
        {
            try
            {
                var lista = paisBusiness.GetPaises();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreatePais([FromBody] Pais entity)
        {
            try
            {
                paisBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdPais}")]
        public IActionResult UpdatePais(int IdPais, [FromBody] Pais entity)
        {
            try
            {
                paisBusiness.Update(IdPais, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}