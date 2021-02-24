using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TerceroController : ControllerBase
    {
        private readonly ITerceroBusiness _Business;

        public TerceroController(ITerceroBusiness business)
        {
            _Business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetTerceros(int id)
        {
            try
            {
                return Ok(_Business.GetTerceros(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CliByIden")]
        public IActionResult GetClienteByIden([FromBody] JObject data)
        {
            try
            {
                var entity = _Business.GetClienteByIden(data);
                return Ok(new { resp = true, entity });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Act/{id}")]
        public IActionResult GetTercerosActivos(int id)
        {
            try
            {
                return Ok(_Business.GetTercerosActivos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tercero entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTercero(int id, [FromBody] Tercero entity)
        {
            try
            {
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Proveedores
        [HttpGet("Prov/{id}")]
        public IActionResult GetProveedores(int id)
        {
            try
            {
                return Ok(_Business.GetProveedores(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Prov/Act/{id}")]
        public IActionResult GetProveedoresActivos(int id)
        {
            try
            {
                return Ok(_Business.GetProveedoresActivos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Prov/{id}")]
        public IActionResult UpdateProveedor(int id, [FromBody] Tercero entity)
        {
            try
            {
                _Business.UpdateProveedor(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Clientes
        [HttpGet("Cli/{id}")]
        public IActionResult GetClientes(int id)
        {
            try
            {
                return Ok(_Business.GetClientes(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Cli/Act/{id}")]
        public IActionResult GetClientesActivos(int id)
        {
            try
            {
                return Ok(_Business.GetClientesActivos(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Cli/{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Tercero entity)
        {
            try
            {
                _Business.UpdateCliente(id, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}