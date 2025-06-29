using Domain.DTOs.PeliculaDTOs;
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
    public class QueryPeliculas : IQueryPelicula
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly ApplicationDbContext _context;

        public QueryPeliculas(IDbConnection connection, Compiler sqlKataCompiler, ApplicationDbContext dbContext)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            this._context = dbContext;
        }

        public ResponseGetPeliculas GetPeliculaByIdQuery(int peliculaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Peliculas")
                .Where("PeliculaId", "=", peliculaId)
                .FirstOrDefault<ResponseGetPeliculas>();

            return new ResponseGetPeliculas
            {
                PeliculaId = query.PeliculaId,
                Titulo = query.Titulo,
                Poster = query.Poster,
                Sinopsis = query.Sinopsis,
                Trailer = query.Trailer
            };
        }

        public ResponseGetPeliculas GetPeliculaByIdQuery2(int peliculaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Peliculas")
                .Where("PeliculaId", "=", peliculaId)
                .FirstOrDefault<ResponseGetPeliculas>();

            return query;
        }

        public List<Pelicula> GetPeliculasByTitulo(string titulo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var peliculas = db.Query("Peliculas")
                .Select("Peliculas.PeliculaId", "Peliculas.Titulo", "Peliculas.Poster", "Peliculas.Sinopsis", "Peliculas.Trailer")
                .When(!string.IsNullOrWhiteSpace(titulo), t => t.Where("Peliculas.Titulo", "=", titulo)).Get<Pelicula>().ToList();

            return peliculas;
        }

        public List<ResponseGetPeliculas> GetPeliculasByTitulo2(string titulo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var peliculas = db.Query("Peliculas")
                .Select("Peliculas.PeliculaId", "Peliculas.Titulo", "Peliculas.Poster", "Peliculas.Sinopsis", "Peliculas.Trailer")
                .When(!string.IsNullOrWhiteSpace(titulo), t => t.Where("Peliculas.Titulo", "=", titulo)).Get<ResponseGetPeliculas>().ToList();

            return peliculas;
        }

        public List<ResponseGetPeliculas> GetAllPeliculas()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var peliculas = db.Query("Peliculas")
                .Select("Peliculas.PeliculaId", "Peliculas.Titulo", "Peliculas.Poster", "Peliculas.Sinopsis", "Peliculas.Trailer")
                .Get<ResponseGetPeliculas>().ToList();

            return peliculas;
        }

    }
}
