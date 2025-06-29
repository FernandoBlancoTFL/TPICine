using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }

        public string Titulo { get; set; }

        public string Poster { get; set; }

        public string Sinopsis { get; set; }

        public string Trailer { get; set; }

        public List<Funcion> Funciones { get; set; }
    }
}
