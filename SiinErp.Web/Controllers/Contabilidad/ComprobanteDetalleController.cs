using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Contabilidad
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobanteDetalleController : ControllerBase
    {
        private readonly IComprobanteDetalleBusiness _Business;

        public ComprobanteDetalleController(IComprobanteDetalleBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                return Ok(_Business.GetAll(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}