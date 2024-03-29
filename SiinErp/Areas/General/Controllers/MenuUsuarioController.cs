﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class MenuUsuarioController : ControllerBase
    {
        private readonly IMenuUsuarioBusiness menuUsuarioBusiness;

        public MenuUsuarioController()
        {
            menuUsuarioBusiness = new MenuUsuarioBusiness();
        }


        [HttpGet("GetMenu/{IdUsu}")]
        public IActionResult GetMenuByIdUsuario(int IdUsu)
        {
            try
            {
                string menu = menuUsuarioBusiness.GetMenuByIdUsuario(IdUsu);
                return Ok(menu);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{IdUsu}")]
        public IActionResult GetAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = menuUsuarioBusiness.GetAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Not/{IdUsu}")]
        public IActionResult GetNotAllByIdUsuario(int IdUsu)
        {
            try
            {
                var lista = menuUsuarioBusiness.GetNotAllByIdUsuario(IdUsu);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MenuUsuario entity)
        {
            try
            {
                menuUsuarioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{IdMenuUsu}")]
        public IActionResult Delete(int IdMenuUsu)
        {
            try
            {
                menuUsuarioBusiness.Delete(IdMenuUsu);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
