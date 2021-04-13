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
    public class PaisController : ControllerBase
    {
        private readonly IPaisBusiness paisBusiness;

        public PaisController(IPaisBusiness _paisBusiness)
        {
            this.paisBusiness = _paisBusiness;
        }

        [HttpGet]
        public IActionResult GetPaises()
        {
            try
            {
                var lista = paisBusiness.GetAll();
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
