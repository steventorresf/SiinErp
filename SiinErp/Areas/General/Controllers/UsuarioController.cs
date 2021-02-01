using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Business;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;

namespace SiinErp.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constantes.Area_General)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness usuarioBusiness;

        public UsuarioController()
        {
            usuarioBusiness = new UsuarioBusiness();
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
                    string Clave = Util.EncriptarMD5(Con);

                    Usuario obUsu = usuarioBusiness.GetByUsuario(Usu, Clave);
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
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("UltAlm/{IdUsu}")]
        public IActionResult GetUltimoIdAlmacenPuntoVenta(int IdUsu)
        {
            try
            {
                int? idDetAlmacen = usuarioBusiness.GetUltimoIdAlmacenPuntoVenta(IdUsu);
                return Ok(idDetAlmacen);
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
                var lista = usuarioBusiness.GetUsuarios();
                return Ok(lista);
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
                usuarioBusiness.Create(entity);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{IdUsu}")]
        public IActionResult UpdateUsuario(int IdUsu, [FromBody] Usuario entity)
        {
            try
            {
                usuarioBusiness.Update(IdUsu, entity);
                return Ok(true);
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
                usuarioBusiness.UpdateEstado(IdUsuario, Estado);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Reset/{IdUsu}")]
        public IActionResult ResetearClave(int IdUsu)
        {
            try
            {
                usuarioBusiness.ResetearClave(IdUsu);
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}