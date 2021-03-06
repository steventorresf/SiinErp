﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Contabilidad.Abstract;
using SiinErp.Areas.Contabilidad.Business;
using SiinErp.Areas.Contabilidad.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Contabilidad)]
    public class TipoContabController : ControllerBase
    {
        private readonly ITipoContabBusiness tipoContabBusiness;

        public TipoContabController()
        {
            tipoContabBusiness = new TipoContabBusiness();
        }

        [HttpGet("{IdEmp}")]
        public IActionResult GetTiposDoc(int IdEmp)
        {
            try
            {
                var lista = tipoContabBusiness.GetTiposContab(IdEmp);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

      

        [HttpGet("Get/{IdEmp}/{TipoDoc}")]
        public IActionResult GetTipoDoc(int IdEmp, string TipoDoc)
        {
            try
            {
                var entity = tipoContabBusiness.GetTipoContab(IdEmp, TipoDoc);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TipoContab entity)
        {
            try
            {
                tipoContabBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdTipoDoc}")]
        public IActionResult Update(int IdTipoDoc, [FromBody] TipoContab entity)
        {
            try
            {
                tipoContabBusiness.Update(IdTipoDoc, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}