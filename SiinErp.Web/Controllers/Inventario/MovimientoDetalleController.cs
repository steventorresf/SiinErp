using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Inventario
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientoDetalleController : ControllerBase
    {
        private readonly IMovimientoDetalleBusiness _Business;

        public MovimientoDetalleController(IMovimientoDetalleBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                return Ok(_Business.GetMovimientosDetalles(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovimientoDetalle entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}