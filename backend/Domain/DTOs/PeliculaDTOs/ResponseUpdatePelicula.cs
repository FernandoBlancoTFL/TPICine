using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.PeliculaDTOs
{
    public class ResponseUpdatePelicula
    {
        public string Titulo { get; set; }

        public string Poster { get; set; }

        public string Trailer { get; set; }

        public string Sinopsis { get; set; }
    }
}
