using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Inventario.Abstract;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientoDetalleController : ControllerBase
    {
        private IMovimientoDetalleBusiness BusinessMovDet;

        public MovimientoDetalleController()
        {
            BusinessMovDet = new MovimientoDetalleBusiness();
        }

        [HttpGet("{IdMov}")]
        public IActionResult GetAll(int IdMov)
        {
            try
            {
                var lista = BusinessMovDet.GetMovimientosDetalles(IdMov);
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
                BusinessMovDet.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}