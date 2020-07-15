using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class TiposDocController : ControllerBase
    {
        private TiposDocBusiness BusinessTiposDoc = new TiposDocBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTiposDoc(int IdEmp)
        {
            try
            {
                var lista = BusinessTiposDoc.GetTiposDoc(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Get/{IdEmp}/{TipoDoc}")]
        public IActionResult GetTipoDoc(int IdEmp, string TipoDoc)
        {
            try
            {
                var entity = BusinessTiposDoc.GetTipoDoc(IdEmp, TipoDoc);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TiposDoc entity)
        {
            try
            {
                BusinessTiposDoc.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdTipoDoc}")]
        public IActionResult Update(int IdTipoDoc, [FromBody] TiposDoc entity)
        {
            try
            {
                BusinessTiposDoc.Update(IdTipoDoc, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}