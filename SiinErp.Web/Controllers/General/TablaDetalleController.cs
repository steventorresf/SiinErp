using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TablaDetalleController : ControllerBase
    {
        private readonly ITablaDetalleBusiness _Business;

        public TablaDetalleController(ITablaDetalleBusiness business)
        {
            _Business = business;
        }

        [HttpGet("ByIdTabEmp/{tabla}/{empresa}")]
        public IActionResult GetTablaDetalles(int tabla, int empresa)
        {
            try
            {
                return Ok(_Business.GetAllTablaDetalleByIdTabEmp(tabla, empresa));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{tabla}/{empresa}")]
        public IActionResult GetTablaEmpresaDetalles(string tabla, int empresa)
        {
            try
            {
                return Ok(_Business.GetTablaEmpresaDetalleByCod(tabla, empresa));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaEmpresaDetalle([FromBody] TablaDetalle entity)
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

        [HttpPut("{id}")]
        public IActionResult UpdateTablaEmpresaDetalle(int id, [FromBody] TablaDetalle entity)
        {
            try
            {
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpOrd/{id}/{orden}")]
        public IActionResult UpdateOrden(int id, short orden)
        {
            try
            {
                _Business.UpdateOrden(id, orden);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}