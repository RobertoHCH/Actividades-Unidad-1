using Actividad_5_Animales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad_5_Animales.Services
{
    public class ClaseService
    {
        public List<Clase> Clases { get; set; }
        public ClaseService()
        {
            using (animalesContext context = new animalesContext())
            {
                Clases = context.Clase.OrderBy(x => x.Nombre).ToList();
            }
        }
    }
}
