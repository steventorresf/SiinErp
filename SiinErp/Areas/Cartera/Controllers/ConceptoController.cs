﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.Cartera.Abstract;
using SiinErp.Areas.Cartera.Business;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Cartera)]
    public class ConceptoController : ControllerBase
    {
        private readonly IConceptoBusiness BusinessCon;

        public ConceptoController()
        {
            BusinessCon = new ConceptoBusiness();
        }

        [HttpGet("{IdEmp}")]
        public IActionResult Get(int IdEmp)
        {
            try
            {
                var lista = BusinessCon.GetConceptos(IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByTipDoc/{IdTipoDoc}")]
        public IActionResult GetByTipoDoc(int IdTipoDoc)
        {
            try
            {
                var lista = BusinessCon.GetConceptosByTipoDoc(IdTipoDoc);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Concepto entity)
        {
            try
            {
                BusinessCon.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdCon}")]
        public IActionResult Update(int IdCon, [FromBody] Concepto entity)
        {
            try
            {
                BusinessCon.Update(IdCon, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}