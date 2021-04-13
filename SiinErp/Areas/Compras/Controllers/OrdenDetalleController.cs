using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Compras;
using SiinErp.Model.Entities.Compras;
using SiinErp.Utiles;

namespace SiinErp.Areas.Compras.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Compras)]
    public class OrdenDetalleController : ControllerBase
    {
        private readonly IOrdenDetalleBusiness ordenDetalleBusiness;

        public OrdenDetalleController(IOrdenDetalleBusiness _ordenDetalleBusiness)
        {
            this.ordenDetalleBusiness = _ordenDetalleBusiness;
        }

        [HttpGet("{IdOrd}")]
        public IActionResult Get(int IdOrd)
        {
            try
            {
                var lista = ordenDetalleBusiness.GetOrdenDetalle(IdOrd);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrdenDetalle entity)
        {
            try
            {
                ordenDetalleBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdDet}")]
        public IActionResult Update(int IdDet, [FromBody] OrdenDetalle entity)
        {
            try
            {
                ordenDetalleBusiness.UpdateOrdenDetalle(IdDet, entity);
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
                ordenDetalleBusiness.DeleteOrdenDetalle(IdDet);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}