using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.Compras;
using SiinErp.Model.Entities.Compras;
using SiinErp.Model.Common;
using System;

namespace SiinErp.Web.Controllers.Compras
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Compras)]
    public class OrdenDetalleController : ControllerBase
    {
        private readonly IOrdenDetalleBusiness OrdenDetalleBusiness;

        public OrdenDetalleController(IOrdenDetalleBusiness ordenDetalleBusiness)
        {
            OrdenDetalleBusiness = ordenDetalleBusiness;
        }

        [HttpGet("{IdOrd}")]
        public IActionResult Get(int IdOrd)
        {
            try
            {
                var lista = OrdenDetalleBusiness.GetOrdenDetalle(IdOrd);
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
                OrdenDetalleBusiness.Create(entity);
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
                OrdenDetalleBusiness.UpdateOrdenDetalle(IdDet, entity);
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
                OrdenDetalleBusiness.DeleteOrdenDetalle(IdDet);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}