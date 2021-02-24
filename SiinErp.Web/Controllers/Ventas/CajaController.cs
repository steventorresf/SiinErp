using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Ventas;
using SiinErp.Model.Entities.Ventas;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Ventas
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Ventas)]
    public class CajaController : ControllerBase
    {
        private readonly ICajaBusiness _Business;

        public CajaController(ICajaBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_Business.GetCajasById(id));
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
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Caja entity)
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

        [HttpGet("GetIdCajaAc/{id}")]
        public IActionResult GetIdCajaActiva(int id)
        {
            try
            {
                return Ok(_Business.GetIdCajaActiva(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("LastIdDetCajeroByUsu/{usuario}/{empresa}")]
        public IActionResult GetLastIdDetCajeroByUsu(string usuario, int empresa)
        {
            try
            {
                return Ok(_Business.GetLastIdDetCajeroByUsu(usuario, empresa));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetSaldoEnCajaActualIdCaja/{id}")]
        public IActionResult GetSaldoEnCajaActual(int id)
        {
            try
            {
                return Ok(_Business.GetSaldoEnCajaActual(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Imp/{id}")]
        public IActionResult ImprimirCaja(int id)
        {
            try
            {
                return Ok(_Business.GetCajaImpresion(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}