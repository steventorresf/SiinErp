using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            catch (Exception ex)
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
                return Ok("Ok");
            }
            catch (Exception ex)
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
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}