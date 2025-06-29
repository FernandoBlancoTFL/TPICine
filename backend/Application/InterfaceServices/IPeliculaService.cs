using Domain;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterfaceService
{
    public interface IPeliculaService
    {
        ResponseGetPeliculas GetPeliculaById(int peliculaId);
        ResponseUpdatePelicula UpdatePelicula(ResponseUpdatePelicula peliculaResponse, int peliculaId);
        CustomResponse<ResponseGetPeliculas> ValidadorPeliculaId(string peliculaId);
        CustomResponse<ResponseGetPeliculas> ValidadorUpdate(string peliculaId);
        List<ResponseGetPeliculas> GetPeliculas();
    }
}
