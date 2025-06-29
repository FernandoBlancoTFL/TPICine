using Application.InterfaceService;
using Domain;
using Domain.Commands;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IGenericsRepository _repository;
        private readonly IQueryPelicula _query;
        private readonly IQueryGeneric _queryGeneric;

        public PeliculaService(IGenericsRepository repository, IQueryPelicula query, IQueryGeneric queryGeneric)
        {
            _repository = repository;
            _query = query;
            _queryGeneric = queryGeneric;
        }

        public ResponseGetPeliculas GetPeliculaById(int Id)
        {
            return _query.GetPeliculaByIdQuery(Id);
        }

        public CustomResponse<ResponseGetPeliculas> ValidadorPeliculaId(string peliculaId)
        {
            var response = new CustomResponse<ResponseGetPeliculas>();
            int pId = 0;
            bool resultado = int.TryParse(peliculaId, out pId);

            if (resultado)
            {
                var listaPeliculas = _queryGeneric.GetAll<Pelicula>();
                listaPeliculas.ForEach(pelicula =>
                {
                    if (pId == pelicula.PeliculaId)
                    {
                        resultado = false;
                    }
                });

                if (!resultado)
                {
                    var pelicula = GetPeliculaById(pId);
                    response.Data = pelicula;
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de película");

            return response;
        }

        public ResponseUpdatePelicula UpdatePelicula(ResponseUpdatePelicula peliculaResponse, int peliculaId)
        {
            var entity = new Pelicula
            {
                PeliculaId = peliculaId,
                Titulo = peliculaResponse.Titulo,
                Poster = peliculaResponse.Poster,
                Trailer = peliculaResponse.Trailer,
                Sinopsis = peliculaResponse.Sinopsis
            };

            _repository.Update(entity);

            return new ResponseUpdatePelicula { Titulo = entity.Titulo, Poster = entity.Poster, Trailer = entity.Trailer, Sinopsis = entity.Sinopsis };
        }

        public CustomResponse<ResponseGetPeliculas> ValidadorUpdate(string peliculaId)
        {
            var response = new CustomResponse<ResponseGetPeliculas>();
            int pId;
            bool resultado = int.TryParse(peliculaId, out pId);

            if (resultado)
            {
                var pelicula = _query.GetPeliculaByIdQuery2(pId);

                if (pelicula != null)
                {
                    response.Data = pelicula;
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de película");

            return response;
        }

        public List<ResponseGetPeliculas> GetPeliculas()
        {
            return _query.GetAllPeliculas();
        }
    }
}
