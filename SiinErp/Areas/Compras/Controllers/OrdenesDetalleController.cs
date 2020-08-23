using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Compras.Business;
using SiinErp.Areas.Compras.Entities;
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrdenesDetalle entity)
        {
            try
            {
                BusinessOrdDet.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdDet}")]
        public IActionResult Update(int IdDet, [FromBody] OrdenesDetalle entity)
        {
            try
            {
                BusinessOrdDet.UpdateOrdenDetalle(IdDet, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{IdDet}")]
        public IActionResult Delete(int IdDet)
        {
            try
            {
                BusinessOrdDet.DeleteOrdenDetalle(IdDet);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}