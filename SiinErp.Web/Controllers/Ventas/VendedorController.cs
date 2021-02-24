using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorBusiness _Business;

        public VendedorController(IVendedorBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_Business.GetVendedores(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Act/{id}")]
        public IActionResult GetActivos(int id)
        {
            try
            {
                return Ok(_Business.GetVendedoresAct(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vendedor entity)
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
        public IActionResult Update(int id, [FromBody] Vendedor entity)
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