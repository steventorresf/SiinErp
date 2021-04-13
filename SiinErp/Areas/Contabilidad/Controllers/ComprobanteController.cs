using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.Contabilidad;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteBusiness comprobanteBusiness;

        public ComprobanteController(IComprobanteBusiness _comprobanteBusiness)
        {
            this.comprobanteBusiness = _comprobanteBusiness;
        }

        [HttpGet("{IdEmp}/{FechaI}/{FechaF}")]
        public IActionResult GetAll(int IdEmp, string FechaI, string FechaF)
        {
            try
            {
                var lista = comprobanteBusiness.GetAll(IdEmp, FechaI, FechaF);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                comprobanteBusiness.Create(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdComp}")]
        public IActionResult Update(int IdComp, [FromBody] JObject data)
        {
            try
            {
                comprobanteBusiness.Update(IdComp, data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdComp}/{ModificadoPor}")]
        public IActionResult Anular(int IdComp, string ModificadoPor)
        {
            try
            {
                comprobanteBusiness.Anular(IdComp, ModificadoPor);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}