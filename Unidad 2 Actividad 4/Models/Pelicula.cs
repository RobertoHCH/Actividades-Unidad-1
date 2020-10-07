﻿using System;
using System.Collections.Generic;

namespace Unidad_2_Actividad_4.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Apariciones = new HashSet<Apariciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public string Descripción { get; set; }
        public DateTime? FechaEstreno { get; set; }

        public virtual ICollection<Apariciones> Apariciones { get; set; }
    }
}
