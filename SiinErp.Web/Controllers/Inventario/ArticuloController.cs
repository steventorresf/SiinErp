using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Inventario
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloBusiness _Business;

        public ArticuloController(IArticuloBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetArticulos(int id)
        {
            try
            {
                return Ok(_Business.GetArticulos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByCodListaP")]
        public IActionResult GetByCodigoListaP([FromBody] JObject data)
        {
            try
            {
                return Ok(_Business.GetByCodigoListaP(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("PrefixListaP")]
        public IActionResult GetByPrefixListaP([FromBody] JObject data)
        {
            try
            {
                return Ok(_Business.GetByPrefixListaP(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByAlmPrefix")]
        public IActionResult GetArticulosByAlmacenPrefix([FromBody] JObject data)
        {
            try
            {
                int detalle = data["IdDetAlm"].ToObject<int>();
                int empresa = data["IdEmp"].ToObject<int>();
                string prefix = data["Prefix"].ToObject<string>();
                return Ok(_Business.GetArticulosByAlmacenPrefix(detalle, empresa, prefix));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Articulo entity)
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
        public IActionResult Update(int id, [FromBody] Articulo entity)
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
    }
}