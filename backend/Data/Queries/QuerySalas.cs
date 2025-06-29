using Domain.DTOs.SalaDTOs;
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
    public class QuerySalas : IQuerySala
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public QuerySalas(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public ResponseGetSalaById GetSalaByIdQuery(int salaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Salas")
                .Where("SalaId", "=", salaId)
                .FirstOrDefault<ResponseGetSalaById>();

            return new ResponseGetSalaById
            {
                SalaId = query.SalaId,
                Capacidad = query.Capacidad
            };
        }
    }
}
