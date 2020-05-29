using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;

namespace SiinErp.Areas.General.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private EmpresasBusiness BusinessEmp = new EmpresasBusiness();

        [HttpGet]
        public IActionResult GetEmpresas()
        {
            try
            {
                var lista = BusinessEmp.GetEmpresas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}