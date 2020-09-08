using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Tesoreria.Business;

using SiinErp.Utiles;

namespace SiinErp.Areas.Tesoreria.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Tesoreria)]
    public class PagosController : ControllerBase
    {
        private PagosBusiness BusinessPag = new PagosBusiness();

        [HttpGet("{IdEmp}/{FechaIni}/{FechaFin}")]
        public IActionResult GetAll(int IdEmp,string FechaIni,string FechaFin)
        {
            try
            {
                var lista = BusinessPag.GetAll(IdEmp, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Pagos entity = data["entity"].ToObject<Pagos>();
                List<PagosDetalle> listDetalleFac = data["listDetalleFac"].ToObject<List<PagosDetalle>>();

                BusinessPag.Create(entity, listDetalleFac);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}