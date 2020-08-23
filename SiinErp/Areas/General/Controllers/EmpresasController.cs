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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Act")]
        public IActionResult GetEmpresasAct()
        {
            try
            {
                var lista = BusinessEmp.GetEmpresasAct();
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateEmpresa([FromBody] Empresas entity)
        {
            try
            {
                BusinessEmp.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdEmp}")]
        public IActionResult UpdateEmpresa(int IdEmp, [FromBody] Empresas entity)
        {
            try
            {
                BusinessEmp.Update(IdEmp, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}