using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TablasDetalleController : ControllerBase
    {
        private TablasDetalleBusiness BusinessTabDet = new TablasDetalleBusiness();

        [HttpGet("ByIdTab/{IdTab}")]
        public IActionResult GetTablaDetalles(int IdTab)
        {
            try
            {
                var lista = BusinessTabDet.GetAllTablaDetalleByIdTab(IdTab);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{CodTab}")]
        public IActionResult GetTablaDetalles(string CodTab)
        {
            try
            {
                var lista = BusinessTabDet.GetTablaDetalleByCod(CodTab);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaDetalle([FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{idDet}")]
        public IActionResult UpdateTablaDetalle(int idDet, [FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Update(idDet, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("UpOrd/{IdDet}/{Orden}")]
        public IActionResult UpdateOrden(int IdDet, short Orden)
        {
            try
            {
                BusinessTabDet.UpdateOrden(IdDet, Orden);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}