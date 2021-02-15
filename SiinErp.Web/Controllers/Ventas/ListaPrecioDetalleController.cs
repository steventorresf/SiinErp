using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class ListaPrecioDetalleController : ControllerBase
    {
        private readonly IListaPrecioDetalleBusiness _Business;

        public ListaPrecioDetalleController(IListaPrecioDetalleBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_Business.GetListaPreciosDetalle(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByPrefix")]
        public IActionResult GetAllByPrefix([FromBody] JObject data)
        {
            try
            {
                return Ok(_Business.GetListaPreciosDetalleByPrefix(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ListaPrecioDetalle entity)
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
        public IActionResult Update(int id, [FromBody] ListaPrecioDetalle entity)
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Business.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}