using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class PaisController : ControllerBase
    {
        private readonly IPaisBusiness _Business;
        private readonly IErrorBusiness _ErrorBusiness;

        public PaisController(IPaisBusiness business, IErrorBusiness errorBusiness)
        {
            _Business = business;
            _ErrorBusiness = errorBusiness;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pais entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                entity.FechaModificado = DateTimeOffset.Now;
                _Business.Create(entity.IdPais, entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _ErrorBusiness.Create("PaisController.Create", ex, null);
                throw;
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_Business.ReadAll());
            }
            catch (Exception ex)
            {
                _ErrorBusiness.Create("PaisController.ReadAll", ex, null);
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pais entity)
        {
            try
            {
                entity.FechaModificado = DateTimeOffset.Now;
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _ErrorBusiness.Create("PaisController.Update", ex, null);
                throw;
            }
        }
    }
}