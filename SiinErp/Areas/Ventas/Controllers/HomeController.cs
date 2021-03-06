﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiinErp.Utiles;

namespace SiinErp.Areas.Ventas.Controllers
{
    [Area(Constantes.Area_Ventas)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaPrecios()
        {
            return View();
        }
        public IActionResult Vendedores()
        {
            return View();
        }
        public IActionResult Clientes()
        {
            return View();
        }
        public IActionResult PuntoDeVenta()
        {
            return View();
        }
        public IActionResult Facturar()
        {
            return View();
        }
        public IActionResult Caja()
        {
            return View();
        }
    }
}