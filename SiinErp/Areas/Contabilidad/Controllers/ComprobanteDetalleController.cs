using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobanteDetalleController : ControllerBase
    {
        private readonly IComprobanteDetalleBusiness comprobanteDetalleBusiness;

        public ComprobanteDetalleController(IComprobanteDetalleBusiness _comprobanteDetalleBusiness)
        {
            this.comprobanteDetalleBusiness = _comprobanteDetalleBusiness;
        }

        [HttpGet("{IdComp}")]
        public IActionResult GetAll(int IdComp)
        {
            try
            {
                var lista = comprobanteDetalleBusiness.GetAll(IdComp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}