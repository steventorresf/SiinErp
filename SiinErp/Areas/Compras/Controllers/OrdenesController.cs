﻿using System;
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
    public class OrdenesController : ControllerBase
    {
        private OrdenesBusiness BusinessOrd = new OrdenesBusiness();

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = BusinessOrd.GetOrdenes(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ordenes entity)
        {
            try
            {
                BusinessOrd.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdOrd}")]
        public IActionResult Update(int IdOrd, [FromBody] Ordenes entity)
        {
            try
            {
                BusinessOrd.Update(IdOrd, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}