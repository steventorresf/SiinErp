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
    public class CajaController : ControllerBase
    {
        private readonly ICajaBusiness cajaBusiness;

        public CajaController()
        {
            cajaBusiness = new CajaBusiness();
        }

        [HttpGet("{IdCajero}")]
        public IActionResult Get(int IdCajero)
        {
            try
            {
                var lista = cajaBusiness.GetCajasById(IdCajero);
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
                cajaBusiness.Create(entity);
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
                cajaBusiness.Update(IdCaja, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetIdCajaAc/{IdCajero}")]
        public IActionResult GetIdCajaActiva(int IdCajero)
        {
            try
            {
                int idCaja = cajaBusiness.GetIdCajaActiva(IdCajero);
                return Ok(idCaja);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("LastIdDetCajeroByUsu/{NomUsu}/{IdEmp}")]
        public IActionResult GetLastIdDetCajeroByUsu(string NomUsu, int IdEmp)
        {
            try
            {
                int idDetCajero = cajaBusiness.GetLastIdDetCajeroByUsu(NomUsu, IdEmp);
                return Ok(idDetCajero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetSaldoEnCajaActualIdCaja/{IdCaja}")]
        public IActionResult GetSaldoEnCajaActual(int IdCaja)
        {
            try
            {
                decimal SaldoEnCaja = cajaBusiness.GetSaldoEnCajaActual(IdCaja);
                return Ok(SaldoEnCaja);
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
                var entity = cajaBusiness.GetCajaImpresion(IdCaja);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}