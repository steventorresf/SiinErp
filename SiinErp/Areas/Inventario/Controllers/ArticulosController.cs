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
    public class ArticulosController : ControllerBase
    {
        private ArticulosBusiness BusinessArt = new ArticulosBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetArticulos(int IdEmp)
        {
            try
            {
                var lista = BusinessArt.GetArticulos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("ByCod")]
        public IActionResult GetArticuloByCodigo([FromBody] JObject data)
        {
            try
            {
                var entity = BusinessArt.GetArticuloByCodigo(data);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Prefix")]
        public IActionResult GetArticulosByPrefix([FromBody] JObject data)
        {
            try
            {
                int IdEmp = data["IdEmp"].ToObject<int>();
                string Prefix = data["Prefix"].ToObject<string>();

                var lista = BusinessArt.GetArticulosByPrefix(IdEmp, Prefix);
                return Ok(lista);
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
                int IdDetAlm = data["IdDetAlm"].ToObject<int>();
                int IdEmp = data["IdEmp"].ToObject<int>();
                string Prefix = data["Prefix"].ToObject<string>();

                var lista = BusinessArt.GetArticulosByAlmacenPrefix(IdDetAlm, IdEmp, Prefix);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Articulos entity)
        {
            try
            {
                BusinessArt.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdArt}")]
        public IActionResult Update(int IdArt, [FromBody] Articulos entity)
        {
            try
            {
                BusinessArt.Update(IdArt, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}