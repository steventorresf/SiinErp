using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Ventas.Business;
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
    }
}