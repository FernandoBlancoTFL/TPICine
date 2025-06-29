using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQueryPelicula
    {
        ResponseGetPeliculas GetPeliculaByIdQuery(int Id);
        List<Pelicula> GetPeliculasByTitulo(string titulo);
        ResponseGetPeliculas GetPeliculaByIdQuery2(int Id);
        List<ResponseGetPeliculas> GetPeliculasByTitulo2(string titulo);
        List<ResponseGetPeliculas> GetAllPeliculas();
    }
}
