using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.FuncionDTOs
{
    public class ResponseAllFunciones
    {
        public int PeliculaId { get; set; }

        public int SalaId { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Horario { get; set; }
    }
}
