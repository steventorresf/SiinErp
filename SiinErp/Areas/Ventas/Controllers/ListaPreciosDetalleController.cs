using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Ventas.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class ListaPreciosDetalleController : ControllerBase
    {
        private ListaPreciosDetalleBusiness BusinessListDet = new ListaPreciosDetalleBusiness();

        [HttpGet("{IdListaD}")]
        public IActionResult Get(int IdListaD)
        {
            try
            {
                var lista = BusinessListDet.GetListaPreciosDetalle(IdListaD);
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
                var lista = BusinessListDet.GetListaPreciosDetalleByPrefix(data);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ListaPreciosDetalle entity)
        {
            try
            {
                BusinessListDet.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdListD}")]
        public IActionResult Update(int IdListD, [FromBody] ListaPreciosDetalle entity)
        {
            try
            {
                BusinessListDet.Update(IdListD, entity);
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
                BusinessListDet.Delete(IdListD);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}