using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        public string Usuario { get; set; }

        public int FuncionId { get; set; }

        [ForeignKey("FuncionId")]
        public Funcion Funciones { get; set; }
    }
}
