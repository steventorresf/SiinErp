using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TiposDocumentoController : ControllerBase
    {
        private TiposDocumentoBusiness BusinessDoc = new TiposDocumentoBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTiposDocumentos(int IdEmp)
        {
            try
            {
                var lista = BusinessDoc.GetTiposDocumentos(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{Cod}")]
        public IActionResult GetTipoDocumento(string Cod)
        {
            try
            {
                var entity = BusinessDoc.GetTipoDocumento(Cod);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("ByCodMod/{IdEmp}/{CodMod}")]
        public IActionResult GetTipoDocumento(int IdEmp, string CodMod)
        {
            try
            {
                var entity = BusinessDoc.GetTiposDocumentosByModulo(IdEmp, CodMod);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTipoDocumento([FromBody] TiposDocumento entity)
        {
            try
            {
                BusinessDoc.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdTipoDoc}")]
        public IActionResult UpdateTipoDocumento(int IdTipoDoc, [FromBody] TiposDocumento entity)
        {
            try
            {
                BusinessDoc.Update(IdTipoDoc, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}