using System;
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

        [HttpPost]
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
    }
}