using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Utiles;

namespace SiinErp.Areas.Compras.Controllers
{
    [Area(Constantes.Area_Compras)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Proveedores()
        {
            return View();
        }
        public IActionResult Ordenes()
        {
            return View();
        }
    }
}