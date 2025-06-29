using Application.InterfaceService;
using Domain;
using Domain.Commands;
using Domain.DTOs.TicketDTOs;
using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IGenericsRepository _repository;
        private readonly IQueryGeneric _queryGeneric;
        private readonly IQueryFuncion _queryFuncion;
        private readonly IQuerySala _querySala;
        private readonly IQueryTicket _queryTicket;

        public TicketService(IGenericsRepository repository, IQueryGeneric queryGeneric, IQueryFuncion queryFuncion, IQuerySala querySala, IQueryTicket queryTicket)
        {
            _repository = repository;
            _queryGeneric = queryGeneric;
            _queryFuncion = queryFuncion;
            _querySala = querySala;
            _queryTicket = queryTicket;
        }

        public List<ResponseTickets> GetTicketsByFuncionId(int id)
        {
            List<ResponseTickets> ListaTicketsResponse = new List<ResponseTickets>();
            var ListaTickets = _queryGeneric.GetAll<Ticket>();

            foreach (var ticket in ListaTickets)
            {
                if (ticket.FuncionId == id)
                {
                    ListaTicketsResponse.Add(new ResponseTickets
                    {
                        FuncionId = ticket.FuncionId,
                        Usuario = ticket.Usuario,
                    });
                }
            }
            return ListaTicketsResponse;
        }

        public TicketDto CreateTicket(ResponseTickets ticket)
        {
            var entity = new Ticket
            {
                TicketId = Guid.NewGuid(),
                Usuario = ticket.Usuario,
                FuncionId = ticket.FuncionId
            };

            _repository.Add(entity);

            return new TicketDto { TicketId = entity.TicketId, Usuario = entity.Usuario, FuncionId = entity.FuncionId};
        }

        public CustomResponse<ResponseTickets> ValidadorTicket(ResponseTickets ticket)
        {
            var response = new CustomResponse<ResponseTickets>();
            int fId, cantidad;
            bool resultado = int.TryParse(ticket.FuncionId.ToString(), out fId);

            if (resultado)
            {
                var listaFunciones = _queryGeneric.GetAll<Funcion>();
                listaFunciones.ForEach(funcion =>
                {
                    if (fId == funcion.FuncionId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    resultado = int.TryParse(ticket.Cantidad.ToString(), out cantidad);
                    resultado = true;
                    if (resultado)
                    {
                        if (cantidad > TicketsDisponibles(fId))
                        {
                            resultado = false;
                        }

                        if (resultado)
                        {
                            var tickets = _queryTicket.GetListaTickestByFuncionIdQuery(fId);
                            response.Data2 = tickets;
                        }
                        else
                            response.Errors.Add("La sala no tiene espacio, no se puede registrar tickets");

                    }
                    else
                        response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese una cantidad expresada en número");
                }
                else
                    response.Errors.Add("No hay una función registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de función");
            return response;
        }

        public int TicketsDisponibles(int funcionId)
        {
            var funcion = _queryFuncion.GetFuncionByIdQuery(funcionId);

            var sala = _querySala.GetSalaByIdQuery(funcion.SalaId);

            var ticketss = GetTicketsByFuncionId(funcionId);

            var tickesDisponibles = sala.Capacidad - ticketss.Count();

            return tickesDisponibles;
        }

    }
}
