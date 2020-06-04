﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Models.General.Business;
using SiinErp.Models.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuariosBusiness BusinessUsu = new UsuariosBusiness();

        [HttpPost("Login")]
        public IActionResult Login([FromBody] JObject data)
        {
            try
            {
                string respuesta = "TodoOkey";
                if (data != null)
                {
                    
                    string Usu = data["nomUsu"].ToObject<string>();
                    string Con = data["clave"].ToObject<string>();
                    string Clave = Util.EncriptarMD5(Con);

                    Usuarios obUsu = BusinessUsu.GetByUsuario(Usu, Clave);
                    if (obUsu != null)
                    {
                        if (obUsu.Estado.Equals(Constantes.EstadoActivo))
                        {
                            HttpContext.Session.SetString("IdUsu", obUsu.IdUsuario.ToString());
                            HttpContext.Session.SetString("NombreUsuario", obUsu.NombreUsuario);
                            HttpContext.Session.SetString("NombreCompleto", obUsu.NombreCompleto);
                            HttpContext.Session.SetString("Imagen", "favicon.ico");
                        }
                        else { respuesta = "Usuario Inactivo."; }
                    }
                    else { respuesta = "Usuario y/o contraseña incorrecta."; }
                }
                else { respuesta = "Hacker"; }

                return Ok(respuesta);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                var lista = BusinessUsu.GetUsuarios();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] Usuarios entity)
        {
            try
            {
                BusinessUsu.Create(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{IdUsu}")]
        public IActionResult UpdateUsuario(int IdUsu, [FromBody] Usuarios entity)
        {
            try
            {
                BusinessUsu.Update(IdUsu, entity);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UpEst")]
        public IActionResult UpdateEstado([FromBody] JObject data)
        {
            try
            {
                int IdUsuario = data["IdUsuario"].ToObject<int>();
                string Estado = data["Estado"].ToObject<string>();
                BusinessUsu.UpdateEstado(IdUsuario, Estado);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("Reset/{IdUsu}")]
        public IActionResult ResetearClave(int IdUsu)
        {
            try
            {
                BusinessUsu.ResetearClave(IdUsu);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}