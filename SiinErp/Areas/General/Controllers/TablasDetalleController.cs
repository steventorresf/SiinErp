﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Models.General.Business;
using SiinErp.Models.General.Entities;

namespace SiinErp.Areas.General.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablasDetalleController : ControllerBase
    {
        private TablasDetalleBusiness BusinessTabDet = new TablasDetalleBusiness();

        [HttpGet("{CodTab}")]
        public IActionResult GetTablaDetalles(string CodTab)
        {
            try
            {
                var lista = BusinessTabDet.GetTablaDetalleByCod(CodTab);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaDetalle([FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{idDet}")]
        public IActionResult UpdateTablaDetalle(int idDet, [FromBody] TablasDetalle entity)
        {
            try
            {
                BusinessTabDet.Update(idDet, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}