using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Inventario.Abstract;
using SiinErp.Areas.Inventario.Business;
using SiinErp.Areas.Inventario.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Inventario)]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloBusiness BusinessArt;

        public ArticuloController()
        {
            BusinessArt = new ArticuloBusiness();
        }

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

        [HttpPost("ByCodListaP")]
        public IActionResult GetByCodigoListaP([FromBody] JObject data)
        {
            try
            {
                var entity = BusinessArt.GetByCodigoListaP(data);
                return Ok(entity);
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
                var lista = BusinessArt.GetByPrefixListaP(data);
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
        public IActionResult Create([FromBody] Articulo entity)
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
        public IActionResult Update(int IdArt, [FromBody] Articulo entity)
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