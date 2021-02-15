using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class CajaDetalleController : ControllerBase
    {
        private readonly ICajaDetalleBusiness _Business;

        public CajaDetalleController(ICajaDetalleBusiness business)
        {
            _Business = business;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CajaDetalle entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCantDetCaja/{id}")]
        public IActionResult GetCantidadDetalleCaja(int id)
        {
            try
            {
                return Ok(_Business.GetCantidadDetalleCaja(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}