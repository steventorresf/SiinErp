using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Ventas.Abstract;
using SiinErp.Areas.Ventas.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class CajaDetalleController : ControllerBase
    {
        private readonly ICajaDetalleBusiness cajaDetalleBusiness;

        public CajaDetalleController()
        {
            cajaDetalleBusiness = new CajaDetalleBusiness();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CajaDetalle entity)
        {
            try
            {
                cajaDetalleBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCantDetCaja/{IdCaja}")]
        public IActionResult GetCantidadDetalleCaja(int IdCaja)
        {
            try
            {
                int cant = cajaDetalleBusiness.GetCantidadDetalleCaja(IdCaja);
                return Ok(cant);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}