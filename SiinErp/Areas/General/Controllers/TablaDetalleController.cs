﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class TablaDetalleController : ControllerBase
    {
        private readonly ITablaDetalleBusiness tablaDetalleBusiness;

        public TablaDetalleController(ITablaDetalleBusiness _tablaDetalleBusiness)
        {
            this.tablaDetalleBusiness = _tablaDetalleBusiness;
        }

        [HttpGet("ByIdTabEmp/{IdTab}/{IdEmp}")]
        public IActionResult GetTablaDetalles(int IdTab, int IdEmp)
        {
            try
            {
                var lista = tablaDetalleBusiness.GetAllTablaDetalleByIdTabEmp(IdTab, IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ByCod/{CodTab}/{IdEmp}")]
        public IActionResult GetTablaEmpresaDetalles(string CodTab, int IdEmp)
        {
            try
            {
                var lista = tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(CodTab, IdEmp);
                return Ok(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateTablaEmpresaDetalle([FromBody] TablaDetalle entity)
        {
            try
            {
                tablaDetalleBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{idDet}")]
        public IActionResult UpdateTablaEmpresaDetalle(int idDet, [FromBody] TablaDetalle entity)
        {
            try
            {
                tablaDetalleBusiness.Update(idDet, entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpOrd/{IdDet}/{Orden}")]
        public IActionResult UpdateOrden(int IdDet, short Orden)
        {
            try
            {
                tablaDetalleBusiness.UpdateOrden(IdDet, Orden);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
