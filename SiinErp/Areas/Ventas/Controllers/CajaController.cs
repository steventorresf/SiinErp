using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Ventas.Business;
using SiinErp.Areas.Ventas.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class CajaController : ControllerBase
    {
        private CajaBusiness BusinessCaja = new CajaBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = BusinessCaja.GetCajas(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Caja entity)
        {
            try
            {
                BusinessCaja.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCaja}")]
        public IActionResult Update(int IdCaja, [FromBody] Caja entity)
        {
            try
            {
                BusinessCaja.Update(IdCaja, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetIdCajaAc/{IdEmp}")]
        public IActionResult GetIdCajaActiva(int IdEmp)
        {
            try
            {
                int idCaja = BusinessCaja.GetIdCajaActiva(IdEmp);
                return Ok(idCaja);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Imp/{IdCaja}")]
        public IActionResult ImprimirCaja(int IdCaja)
        {
            try
            {
                var entity = BusinessCaja.GetCajaImpresion(IdCaja);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}