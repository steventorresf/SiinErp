﻿using System;
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
    public class DepartamentosController : ControllerBase
    {
        private DepartamentosBusiness BusinessDep = new DepartamentosBusiness();

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            try
            {
                var lista = BusinessDep.GetDepartamentos();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateDepartamento([FromBody] Departamentos entity)
        {
            try
            {
                BusinessDep.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdDep}")]
        public IActionResult UpdateDepartamento(int IdDep, [FromBody] Departamentos entity)
        {
            try
            {
                BusinessDep.Update(IdDep, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}