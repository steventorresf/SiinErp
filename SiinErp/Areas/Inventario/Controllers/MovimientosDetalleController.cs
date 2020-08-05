using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class MovimientosDetalleController : ControllerBase
    {
        private MovimientosDetalleBusiness BusinessMovDet = new MovimientosDetalleBusiness();

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
        public IActionResult Create([FromBody] MovimientosDetalle entity)
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