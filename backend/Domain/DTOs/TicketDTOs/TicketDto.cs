using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.TicketDTOs
{
    public class TicketDto
    {

        public Guid TicketId { get; set; }

        public string Usuario { get; set; }

        public int FuncionId { get; set; }
    }
}
