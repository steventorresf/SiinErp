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
    public class TablasEmpresaDetalleController : ControllerBase
    {
        private TablasEmpresaDetalleBusiness BusinessTabDet = new TablasEmpresaDetalleBusiness();

        [HttpGet("ByIdTabEmp/{IdTabEmp}")]
        public IActionResult GetTablaDetalles(int IdTabEmp)
        {
            try
            {
                var lista = BusinessTabDet.GetAllTablaDetalleByIdTabEmp(IdTabEmp);
                return Ok(lista);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaEmpresaDetalle([FromBody] TablasEmpresaDetalle entity)
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
        public IActionResult UpdateTablaEmpresaDetalle(int idDet, [FromBody] TablasEmpresaDetalle entity)
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