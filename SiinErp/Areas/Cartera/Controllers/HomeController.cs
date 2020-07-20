using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Utiles;

namespace SiinErp.Areas.Cartera.Controllers
{
    [Area(Constantes.Area_Cartera)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PlazosPago()
        {
            return View();
        }
        public IActionResult Conceptos()
        {
            return View();
        }
        public IActionResult Movimientos()
        {
            return View();
        }
    }
}