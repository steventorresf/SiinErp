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
    public class TablasEmpresaController : ControllerBase
    {
        private TablasEmpresaBusiness BusinessTab = new TablasEmpresaBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult GetTablasEmpresa(int IdEmp)
        {
            try
            {
                var lista = BusinessTab.GetTablasEmpresa(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaEmpresa([FromBody] TablasEmpresa entity)
        {
            try
            {
                BusinessTab.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTabEmp}")]
        public IActionResult UpdateTablaEmpresa(int IdTabEmp, [FromBody] TablasEmpresa entity)
        {
            try
            {
                BusinessTab.Update(IdTabEmp, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}