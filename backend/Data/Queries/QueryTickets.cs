using Domain.DTOs.TicketDTOs;
using Domain.Entities;
using Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Data.Queries
{
    public class QueryTickets : IQueryTicket
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public QueryTickets(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseTickets> GetListaTickestByFuncionIdQuery(int funcionId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            List<ResponseTickets> ListaResponseTickets = new List<ResponseTickets>();

            var tickets = db.Query("Tickets")
                .Select("Tickets.FuncionId", "Tickets.Usuario")
                .Where("Tickets.FuncionId", "=", funcionId)
                .When(!string.IsNullOrWhiteSpace(funcionId.ToString()), t => t.Where("Tickets.FuncionId", "=", funcionId)).Get<Ticket>().ToList();

            foreach (var ticket in tickets)
            {
                ListaResponseTickets.Add(new ResponseTickets
                {
                    FuncionId = ticket.FuncionId,
                    Usuario = ticket.Usuario
                });
            }

            return ListaResponseTickets;
        }
        
    }
}
