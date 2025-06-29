using Domain;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterfaceService
{
    public interface IFuncionService
    {
        FuncionDto CreateFuncion(FuncionDto funcion);
        ResponseAllFunciones DeleteFuncion(int id);
        CustomResponse<ResponseAllFunciones> ValidadorDelete(string funcionId);
        List<FuncionDto> GetFuncionesByPeliculaId(int PeliculaId);
        List<FuncionDto> FuncionesByPeliculaId(int PeliculaId);
        int GetTicketsAvailabilityByFuncionId(int Id);
        List<ResponseAllFunciones> GetAllFunciones(string Fecha, string Titulo);
        IEnumerable<ResponseGetPeliculas> GetAllPeliculasFunciones(string fecha, string titulo);
        IEnumerable<ResponseGetPeliculas> GetAllPeliculasFuncionesBusqueda(string fecha, string titulo);
        CustomResponse<ResponseAllFunciones> ValidadorFuncionesActuales(IEnumerable<ResponseGetPeliculas> lista);
        List<FuncionDto> GetAllHorarioFunciones(int peliculaId, string fecha);
        CustomResponse<ResponseAllFunciones> ValidadorFuncionFechaTitulo(string fecha, string titulo);
        CustomResponse<FuncionDto> ValidadorFuncion(FuncionDto funcion);
        CustomResponse<ResponseGetPeliculas> ValidadorFuncionByPeliculaId(string peliculaId);
        CustomResponse<ResponseAllFunciones> ValidadorFuncionById(string funcionId);
        int GetFuncionId(string fecha, string horario, int peliculaId, int salaId);
        bool GetFuncionId2(string fecha, string horario, int peliculaId, int salaId);
        bool CapacidadSala(int funcionId);
    }
}
