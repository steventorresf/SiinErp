using Microsoft.AspNetCore.Mvc;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Controllers
{
    [Area(Constantes.Area_General)]
    public class HomeController : Controller
    {
        public IActionResult Empresas()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View();
        }
        public IActionResult Tablas()
        {
            return View();
        }
        public IActionResult DptosCiudads()
        {
            return View();
        }
        public IActionResult TiposDocumento()
        {
            return View();
        }
        public IActionResult Periodos()
        {
            return View();
        }
        public IActionResult Parametros()
        {
            return View();
        }
        public IActionResult Terceros()
        {
            return View();
        }
    }
}
