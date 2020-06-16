using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Compras.Business;
using SiinErp.Areas.Compras.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Compras.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Compras)]
    public class ProveedoresController : ControllerBase
    {
        private ProveedoresBusiness BusinessProv = new ProveedoresBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetArticulos(int IdEmp)
        {
            try
            {
                var lista = BusinessProv.GetProveedores(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Proveedores entity)
        {
            try
            {
                BusinessProv.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdProv}")]
        public IActionResult Update(int IdProv, [FromBody] Proveedores entity)
        {
            try
            {
                BusinessProv.Update(IdProv, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}