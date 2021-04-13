using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TerceroController : ControllerBase
    {
        private readonly ITerceroBusiness terceroBusiness;

        public TerceroController(ITerceroBusiness _terceroBusiness)
        {
            this.terceroBusiness = _terceroBusiness;
        }

        [HttpGet("{IdEmp}")]
        public IActionResult GetTerceros(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetTerceros(IdEmp);
                return Ok(lista);
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
                var entity = terceroBusiness.GetClienteByIden(data);
                return Ok(new { resp = true, entity });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Act/{IdEmp}")]
        public IActionResult GetTercerosActivos(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetTercerosActivos(IdEmp);
                return Ok(lista);
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
                terceroBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTer}")]
        public IActionResult UpdateTercero(int IdTer, [FromBody] Tercero entity)
        {
            try
            {
                terceroBusiness.Update(IdTer, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Proveedores
        [HttpGet("Prov/{IdEmp}")]
        public IActionResult GetProveedores(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetProveedores(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Prov/Act/{IdEmp}")]
        public IActionResult GetProveedoresActivos(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetProveedoresActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Prov/{IdProv}")]
        public IActionResult UpdateProveedor(int IdProv, [FromBody] Tercero entity)
        {
            try
            {
                terceroBusiness.UpdateProveedor(IdProv, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Clientes
        [HttpPost("CliReturn")]
        public IActionResult CreateCliAndReturn([FromBody] Tercero entity)
        {
            try
            {
                terceroBusiness.Create(entity);

                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Cli/{IdEmp}")]
        public IActionResult GetClientes(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetClientes(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CliByPrefix")]
        public IActionResult GetClientesByPrefix([FromBody] JObject data)
        {
            try
            {
                var lista = "";// terceroBusiness.GetClientesByPrefix(data);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Cli/Act/{IdEmp}")]
        public IActionResult GetClientesActivos(int IdEmp)
        {
            try
            {
                var lista = terceroBusiness.GetClientesActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Cli/{IdCli}")]
        public IActionResult UpdateCliente(int IdCli, [FromBody] Tercero entity)
        {
            try
            {
                terceroBusiness.UpdateCliente(IdCli, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
