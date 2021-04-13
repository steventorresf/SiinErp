using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class ListaPrecioDetalleController : ControllerBase
    {
        private readonly IListaPrecioDetalleBusiness listaPrecioDetalleBusiness;

        public ListaPrecioDetalleController(IListaPrecioDetalleBusiness _listaPrecioDetalleBusiness)
        {
            this.listaPrecioDetalleBusiness = _listaPrecioDetalleBusiness;
        }

        [HttpGet("{IdListaD}")]
        public IActionResult Get(int IdListaD)
        {
            try
            {
                var lista = listaPrecioDetalleBusiness.GetListaPreciosDetalle(IdListaD);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("ByPrefix")]
        public IActionResult GetAllByPrefix([FromBody] JObject data)
        {
            try
            {
                var lista = listaPrecioDetalleBusiness.GetListaPreciosDetalleByPrefix(data);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ListaPrecioDetalle entity)
        {
            try
            {
                listaPrecioDetalleBusiness.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdListD}")]
        public IActionResult Update(int IdListD, [FromBody] ListaPrecioDetalle entity)
        {
            try
            {
                listaPrecioDetalleBusiness.Update(IdListD, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdListD}")]
        public IActionResult Delete(int IdListD)
        {
            try
            {
                listaPrecioDetalleBusiness.Delete(IdListD);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}