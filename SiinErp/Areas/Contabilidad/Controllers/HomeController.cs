using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Utiles;

namespace SiinErp.Areas.Contabilidad.Controllers
{
    [Area(Constantes.Area_Contabilidad)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PlanDeCuentas()
        {
            return View();
        }
        public IActionResult Retenciones()
        {
            return View();
        }
        public IActionResult TiposContab()
        {
            return View();
        }
        public IActionResult Comprobantes()
        {
            return View();
        }

    }
}