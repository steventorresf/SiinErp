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

        [HttpGet("ByIdTabEmp/{IdTab}/{IdEmp}")]
        public IActionResult GetTablaDetalles(int IdTab, int IdEmp)
        {
            try
            {
                var lista = BusinessTabDet.GetAllTablaDetalleByIdTabEmp(IdTab, IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{CodTab}/{IdEmp}")]
        public IActionResult GetTablaEmpresaDetalles(string CodTab, int IdEmp)
        {
            try
            {
                var lista = BusinessTabDet.GetTablaEmpresaDetalleByCod(CodTab, IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaEmpresaDetalle([FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{idDet}")]
        public IActionResult UpdateTablaEmpresaDetalle(int idDet, [FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Update(idDet, entity);
                return Ok(true);
            }
            catch (Exception)
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
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}