using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Utiles;

namespace SiinErp.Areas.Inventario.Controllers
{
    [Area(Constantes.Area_Inventario)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Articulos()
        {
            return View();
        }
        public IActionResult TiposDoc()
        {
            return View();
        }
        public IActionResult EntradasPorCompra()
        {
            return View();
        }
    }
}