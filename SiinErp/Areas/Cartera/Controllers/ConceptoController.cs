using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Entities.Cartera;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class ConceptoController : ControllerBase
    {
        private readonly IConceptoBusiness conceptoBusiness;

        public ConceptoController(IConceptoBusiness _conceptoBusiness)
        {
            this.conceptoBusiness = _conceptoBusiness;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = conceptoBusiness.GetConceptos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByTipDoc/{IdTipoDoc}")]
        public IActionResult GetByTipoDoc(int IdTipoDoc)
        {
            try
            {
                var lista = conceptoBusiness.GetConceptosByTipoDoc(IdTipoDoc);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Concepto entity)
        {
            try
            {
                conceptoBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCon}")]
        public IActionResult Update(int IdCon, [FromBody] Concepto entity)
        {
            try
            {
                conceptoBusiness.Update(IdCon, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}