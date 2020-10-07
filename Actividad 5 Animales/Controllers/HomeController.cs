using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad_5_Animales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_5_Animales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();
            animalesViewModel avm = new animalesViewModel();
            avm.clase = context.Clase.OrderBy(x => x.Nombre.ToUpper());
            Random r = new Random();
            avm.Imagen = r.Next(1, 6);
            return View(avm);
        }
        [Route("{id}")]
        public IActionResult Clases(string id)
        {
            var nombre = id.Replace("-", " ").ToLower();
            animalesContext context = new animalesContext();
            var cat = context.Clase.Include(x => x.Especies).ThenInclude(x => x.IdClaseNavigation).OrderBy(x => x.Nombre).FirstOrDefault(x => x.Nombre.ToLower() == nombre);
            if (cat == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cat);
            }
        }
    }
}
