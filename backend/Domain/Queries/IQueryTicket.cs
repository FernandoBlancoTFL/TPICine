using Domain.DTOs.TicketDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQueryTicket
    {
        List<ResponseTickets> GetListaTickestByFuncionIdQuery(int funcionId);
    }
}
