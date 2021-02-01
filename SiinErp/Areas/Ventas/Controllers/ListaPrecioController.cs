using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Ventas.Abstract;
using SiinErp.Areas.Ventas.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class ListaPrecioController : ControllerBase
    {
        private readonly IListaPrecioBusiness listaPrecioBusiness;

        public ListaPrecioController()
        {
            listaPrecioBusiness = new ListaPrecioBusiness();
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = listaPrecioBusiness.GetListaPrecios(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ListaPrecio entity)
        {
            try
            {
                listaPrecioBusiness.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdListP}")]
        public IActionResult Update(int IdListP, [FromBody] ListaPrecio entity)
        {
            try
            {
                listaPrecioBusiness.Update(IdListP, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}