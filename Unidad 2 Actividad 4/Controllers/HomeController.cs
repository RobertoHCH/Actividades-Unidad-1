using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad_2_Actividad_4.Models;

namespace Unidad_2_Actividad_4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Peliculas()
        {
            pixarContext context = new pixarContext();
            var pelicula = context.Pelicula.OrderBy(x => x.Nombre);
            if (pelicula == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pelicula);
            }
        }
        [Route("{id}")]
        public IActionResult Pelicula(string id)
        {
            var nombre = id.Replace("-", " ").ToLower();
            pixarContext context = new pixarContext();
            var pelicula = context.Pelicula.Include(x => x.Apariciones).ThenInclude(x => x.IdPersonajeNavigation).FirstOrDefault(x => x.Nombre.ToLower() == nombre);

            if (pelicula == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
               personajeViewModel pvm = new personajeViewModel();
               pvm.NomPelicula = pelicula.Nombre;
               pvm.Id = pelicula.Id;
               pvm.NomOriginal = pelicula.NombreOriginal;
               pvm.FechaEstreno = pelicula.FechaEstreno;
               pvm.Descripcion = pelicula.Descripción;
               pvm.apariciones = pelicula.Apariciones;
                return View(pvm);
            }
        }
        public IActionResult Cortos()
        {
            pixarContext contexto = new pixarContext();
            cortosViewModel cvm = new cortosViewModel();
            cvm.categorias = contexto.Categoria.Include(x => x.Cortometraje);
            return View(cvm);
        }
        [Route("{id}/Cortometraje")]
        public IActionResult Cortometraje(string id)
        {
            var nombre = id.Replace("_", " ").ToLower();
            pixarContext context = new pixarContext();
            var cortometraje = context.Cortometraje.FirstOrDefault(x => x.Nombre == nombre);
            if (cortometraje == null)
            {
                return RedirectToAction("Cortos");
            }
            else
            {
                return View(cortometraje);
            }
        }
    }
}
