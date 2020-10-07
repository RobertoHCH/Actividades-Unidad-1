﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unidad_2_Actividad_3_Villancicos.Models;

namespace Unidad_2_Actividad_3_Villancicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.OrderBy(x => x.Nombre);

            return View(villancico);
        }
        public IActionResult Villancicos(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.FirstOrDefault(x => x.Id == id);

            if (villancico == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(villancico);
            }

        }
    }
}
