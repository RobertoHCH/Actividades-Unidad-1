using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unidad_2_Actividad_4.Models
{
    public class personajeViewModel
    {
        public string NomPelicula { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Descripcion { get; set; }
        public string NomOriginal { get; set; }
        public int Id { get; set; }
        public IEnumerable<Apariciones> apariciones { get; set; }
    }
}
