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
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorBusiness vendedorBusiness;

        public VendedorController()
        {
            vendedorBusiness = new VendedorBusiness();
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = vendedorBusiness.GetVendedores(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Act/{IdEmp}")]
        public IActionResult GetActivos(int IdEmp)
        {
            try
            {
                var lista = vendedorBusiness.GetVendedoresAct(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vendedor entity)
        {
            try
            {
                vendedorBusiness.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdVen}")]
        public IActionResult Update(int IdVen, [FromBody] Vendedor entity)
        {
            try
            {
                vendedorBusiness.Update(IdVen, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}