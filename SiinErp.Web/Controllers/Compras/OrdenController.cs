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
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenBusiness OrdenBusiness;

        public OrdenController(IOrdenBusiness ordenBusiness)
        {
            OrdenBusiness = ordenBusiness;
        }

        [HttpGet("{IdEmp}/{FechaIni}/{FechaFin}")]
        public IActionResult Get(int IdEmp, string FechaIni, string FechaFin)
        {
            try
            {
                var lista = OrdenBusiness.GetOrdenes(IdEmp, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetPen/{IdEmp}")]
        public IActionResult GetPendientes(int IdEmp)
        {
            try
            {
                var lista = OrdenBusiness.GetOrdenesPendientes(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Orden entity)
        {
            try
            {
                OrdenBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdOrd}")]
        public IActionResult Update(int IdOrd, [FromBody] Orden entity)
        {
            try
            {
                OrdenBusiness.Update(IdOrd, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}