using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class FuncionDto
    {
        public int PeliculaId { get; set; }

        public int SalaId { get; set; }

        public string Fecha { get; set; }

        public string Horario { get; set; }
    }
}
