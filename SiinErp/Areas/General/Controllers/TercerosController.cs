using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TercerosController : ControllerBase
    {
        private TercerosBusiness BusinessTer = new TercerosBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTerceros(int IdEmp)
        {
            try
            {
                var lista = BusinessTer.GetTerceros(IdEmp);
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
                var lista = BusinessTer.GetClienteByIden(data);
                return Ok(lista);
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
                var lista = BusinessTer.GetTercerosActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTer}")]
        public IActionResult UpdateTercero(int IdTer, [FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.Update(IdTer, entity);
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
                var lista = BusinessTer.GetProveedores(IdEmp);
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
                var lista = BusinessTer.GetProveedoresActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Prov/{IdProv}")]
        public IActionResult UpdateProveedor(int IdProv, [FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.UpdateProveedor(IdProv, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Clientes
        [HttpGet("Cli/{IdEmp}")]
        public IActionResult GetClientes(int IdEmp)
        {
            try
            {
                var lista = BusinessTer.GetClientes(IdEmp);
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
                var lista = BusinessTer.GetClientesActivos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Cli/{IdCli}")]
        public IActionResult UpdateCliente(int IdCli, [FromBody] Terceros entity)
        {
            try
            {
                BusinessTer.UpdateCliente(IdCli, entity);
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