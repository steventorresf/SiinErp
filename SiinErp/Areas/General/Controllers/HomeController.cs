using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiinErp.Areas.General.Controllers
{
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
    }
}