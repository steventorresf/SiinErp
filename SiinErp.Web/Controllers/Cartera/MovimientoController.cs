using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Util;
using System;
using System.Collections.Generic;

namespace SiinErp.Web.Controllers.Cartera
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoCarBusiness BusinessMov;

        public MovimientoController(IMovimientoCarBusiness businessMov)
        {
            BusinessMov = businessMov;
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                MovimientoCar entity = data["entity"].ToObject<MovimientoCar>();
                List<Movimiento> listDetalleFac = data["listDetalleFac"].ToObject<List<Movimiento>>();

                BusinessMov.Create(entity, listDetalleFac);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{IdEmpresa}/{FechaIni}/{FechaFin}")]
        public IActionResult GetAll(int IdEmpresa, string FechaIni, string FechaFin)
        {
            try
            {
                var lista = BusinessMov.GetAll(IdEmpresa, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("An/{IdMov}/{NomUsu}")]
        public IActionResult Anular(int IdMov, string NomUsu)
        {
            try
            {
                BusinessMov.Anular(IdMov, NomUsu);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}