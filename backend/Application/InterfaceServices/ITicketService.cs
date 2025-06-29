using Domain;
using Domain.DTOs.TicketDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterfaceService
{
    public interface ITicketService
    {
        TicketDto CreateTicket(ResponseTickets ticket);
        List<ResponseTickets> GetTicketsByFuncionId(int id);
        CustomResponse<ResponseTickets> ValidadorTicket(ResponseTickets ticket);
        int TicketsDisponibles(int funcionId);
    }
}
