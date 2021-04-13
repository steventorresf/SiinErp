using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoCarBusiness movimientoCarBusiness;

        public MovimientoController(IMovimientoCarBusiness _movimientoCarBusiness)
        {
            this.movimientoCarBusiness = _movimientoCarBusiness;
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                MovimientoCar entity = data["entity"].ToObject<MovimientoCar>();
                List<Movimiento> listDetalleFac = data["listDetalleFac"].ToObject<List<Movimiento>>();

                movimientoCarBusiness.Create(entity, listDetalleFac);
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
                var lista = movimientoCarBusiness.GetAll(IdEmpresa, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
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
                movimientoCarBusiness.Anular(IdMov, NomUsu);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}