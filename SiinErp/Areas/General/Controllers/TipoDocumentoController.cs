using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoBusiness tipoDocumentoBusiness;

        public TipoDocumentoController()
        {
            tipoDocumentoBusiness = new TipoDocumentoBusiness();
        }

        [HttpGet("{IdEmp}")]
        public IActionResult GetTiposDocumentos(int IdEmp)
        {
            try
            {
                var lista = tipoDocumentoBusiness.GetTiposDocumentos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{IdEmp}/{Cod}")]
        public IActionResult GetByTipoDocumento(int IdEmp, string Cod)
        {
            try
            {
                var entity = tipoDocumentoBusiness.GetTipoDocumento(IdEmp, Cod);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCodMod/{IdEmp}/{CodMod}")]
        public IActionResult GetTipoDocumento(int IdEmp, string CodMod)
        {
            try
            {
                var entity = tipoDocumentoBusiness.GetTiposDocumentosByModulo(IdEmp, CodMod);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTipoDocumento([FromBody] TipoDocumento entity)
        {
            try
            {
                tipoDocumentoBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTipoDoc}")]
        public IActionResult UpdateTipoDocumento(int IdTipoDoc, [FromBody] TipoDocumento entity)
        {
            try
            {
                tipoDocumentoBusiness.Update(IdTipoDoc, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}