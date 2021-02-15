using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Util;
using System;

namespace SiinErp.Web.Controllers.General
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _Business;

        public UsuarioController(IUsuarioBusiness business)
        {
            _Business = business;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] JObject data)
        {
            try
            {
                string respuesta = "TodoOkey";
                Cookies dataCookie = new Cookies();
                if (data != null)
                {
                    int IdEmp = data["idEmp"].ToObject<int>();
                    string Usu = data["nomUsu"].ToObject<string>();
                    string Con = data["clave"].ToObject<string>();
                    string Clave = Seguridad.EncriptarMD5(Con);

                    Usuario obUsu = _Business.GetByUsuario(Usu, Clave);
                    if (obUsu != null)
                    {
                        if (obUsu.Estado.Equals(Constantes.EstadoActivo))
                        {
                            dataCookie.IdUsu = obUsu.IdUsuario;
                            dataCookie.NombreUsuario = obUsu.NombreUsuario;
                            dataCookie.NombreCompleto = obUsu.NombreCompleto;
                            dataCookie.Imagen = "favicon.ico";
                            dataCookie.IdEmpresa = IdEmp;

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

                dataCookie.Respuesta = respuesta;
                return Ok(dataCookie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("UltAlm/{id}")]
        public IActionResult GetUltimoIdAlmacenPuntoVenta(int id)
        {
            try
            {
                return Ok(_Business.GetUltimoIdAlmacenPuntoVenta(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                return Ok(_Business.GetUsuarios());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] Usuario entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] Usuario entity)
        {
            try
            {
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception)
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
                _Business.UpdateEstado(IdUsuario, Estado);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Reset/{id}")]
        public IActionResult ResetearClave(int id)
        {
            try
            {
                _Business.ResetearClave(id);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}