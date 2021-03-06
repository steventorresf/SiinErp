﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.Tesoreria.Entities;
using SiinErp.Areas.Tesoreria.Business;

using SiinErp.Utiles;
using SiinErp.Areas.Tesoreria.Abstract;

namespace SiinErp.Areas.Tesoreria.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_Tesoreria)]
    public class PagoController : ControllerBase
    {
        private readonly IPagoBusiness pagoBusiness;

        public PagoController()
        {
            pagoBusiness = new PagoBusiness();
        }

        [HttpGet("{IdEmp}/{FechaIni}/{FechaFin}")]
        public IActionResult GetAll(int IdEmp,string FechaIni,string FechaFin)
        {
            try
            {
                var lista = pagoBusiness.GetAll(IdEmp, Convert.ToDateTime(FechaIni), Convert.ToDateTime(FechaFin));
                return Ok(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] JObject data)
        {
            try
            {
                Pago entity = data["entity"].ToObject<Pago>();
                List<PagoDetalle> listDetalleFac = data["listDetalleFac"].ToObject<List<PagoDetalle>>();

                pagoBusiness.Create(entity, listDetalleFac);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}