using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad_5_Animales.Models
{
    public class animalesViewModel
    {
        public int Imagen { get; set; }
        public IEnumerable<Clase> clase { get; set; }
    }
}
