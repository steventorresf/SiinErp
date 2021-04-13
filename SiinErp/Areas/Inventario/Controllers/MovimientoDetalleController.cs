using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientoDetalleController : ControllerBase
    {
        private readonly IMovimientoDetalleBusiness movimientoDetalleBusiness;

        public MovimientoDetalleController(IMovimientoDetalleBusiness _movimientoDetalleBusiness)
        {
            this.movimientoDetalleBusiness = _movimientoDetalleBusiness;
        }

        [HttpGet("{IdMov}")]
        public IActionResult GetAll(int IdMov)
        {
            try
            {
                var lista = movimientoDetalleBusiness.GetMovimientosDetalles(IdMov);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovimientoDetalle entity)
        {
            try
            {
                movimientoDetalleBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}