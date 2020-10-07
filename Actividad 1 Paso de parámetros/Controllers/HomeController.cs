using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad_1_Paso_de_parámetros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_1_Paso_de_parámetros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Capturar()
        {
            return View();
        }

        public IActionResult ObtenerResultadoSuma(Valores a)
        {
            var resultado = a.Valor1 + a.Valor2;
            return View(resultado);
        }
    }
}
