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
    public class FacturasVenController : ControllerBase
    {
        private FacturasVenBusiness BusinessFact = new FacturasVenBusiness();

        [HttpGet("LastAlm/{IdUsu}")]
        public IActionResult GetLastIdAlmacenPuntoVenta(int IdUsu)
        {
            try
            {
                var idDetAlmacen = BusinessFact.GetLastIdAlmacenPuntoVenta(IdUsu);
                return Ok(idDetAlmacen);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("PenCli/{IdCli}")]
        public IActionResult GetPendientesByCli(int IdCli)
        {
            try
            {
                var lista = BusinessFact.GetPendientesByCli(IdCli);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByFecha/{IdEmp}/{Fecha}")]
        public IActionResult GetFacturasByFecha(int IdEmp, string Fecha)
        {
            try
            {
                var lista = BusinessFact.GetFacturasByFecha(IdEmp, DateTimeOffset.Parse(Fecha));
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdFac}")]
        public IActionResult UpdateFactura(int IdFac, [FromBody] FacturasVen entity)
        {
            try
            {
                BusinessFact.Update(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdFac}")]
        public IActionResult AnularFactura(int IdFac)
        {
            try
            {
                BusinessFact.Anular(IdFac);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}