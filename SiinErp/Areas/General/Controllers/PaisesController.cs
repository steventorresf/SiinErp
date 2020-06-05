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
    public class PaisesController : ControllerBase
    {
        private PaisesBusiness BusinessPais = new PaisesBusiness();

        [HttpGet]
        public IActionResult GetPaises()
        {
            try
            {
                var lista = BusinessPais.GetPaises();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreatePais([FromBody] Paises entity)
        {
            try
            {
                BusinessPais.Create(entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdPais}")]
        public IActionResult UpdatePais(int IdPais, [FromBody] Paises entity)
        {
            try
            {
                BusinessPais.Update(IdPais, entity);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}