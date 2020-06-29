using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Compras.Business;
using SiinErp.Utiles;

namespace SiinErp.Areas.Compras.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Compras)]
    public class OrdenesDetalleController : ControllerBase
    {
        private OrdenesDetalleBusiness BusinessOrdDet = new OrdenesDetalleBusiness();

        [HttpGet("{IdOrd}")]
        public IActionResult Get(int IdOrd)
        {
            try
            {
                var lista = BusinessOrdDet.GetOrdenDetalle(IdOrd);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}