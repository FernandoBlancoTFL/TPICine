using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Sala
    {
        public int SalaId { get; set; }

        public int Capacidad { get; set; }

        public List<Funcion> Funciones { get; set; }
    }
}
