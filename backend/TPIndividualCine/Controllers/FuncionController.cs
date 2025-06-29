using Application.InterfaceService;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace TPIndividualCine.Controllers
{
    [Route("api/funcion")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService _service;

        public FuncionController(IFuncionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllFunciones([FromQuery] string fecha, [FromQuery] string titulo)
        {
            var response = _service.ValidadorFuncionFechaTitulo(fecha, titulo);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetAllFunciones(fecha, titulo)) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [Route("buscador")]
        [HttpGet]
        public IActionResult GetAllPeliculasFunciones([FromQuery] string fecha, [FromQuery] string titulo)
        {
            var response = _service.ValidadorFuncionFechaTitulo(fecha, titulo);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetAllPeliculasFuncionesBusqueda(fecha, titulo)) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [Route("peliculas")]
        [HttpGet]
        public IActionResult GetAllPeliculasFunciones() 
        {
            var peliculas = _service.GetAllPeliculasFunciones("","");
            var response = _service.ValidadorFuncionesActuales(peliculas);

            if (response.IsValid)
            {
                return new JsonResult(peliculas) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [Route("peliculas/horarios")]
        [HttpGet]
        public IActionResult GetAllFuncionesHorarios(int id, string fecha)
        {
            return new JsonResult(_service.GetAllHorarioFunciones(id, fecha)) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult Post(FuncionDto funcion)
        {
            var response = _service.ValidadorFuncion(funcion);

            if (response.IsValid)
            {
                return new JsonResult(_service.CreateFuncion(funcion)) { StatusCode = 201 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var response = _service.ValidadorDelete(id);
            if (response.IsValid)
            {
                return new JsonResult(_service.DeleteFuncion(int.Parse(id)));
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 404 };
            }
        }

        [Route("pelicula/{peliculaId}")]
        [HttpGet]
        public IActionResult GetFuncionesByPeliculaId(string peliculaId)
        {
            var response = _service.ValidadorFuncionByPeliculaId(peliculaId);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetFuncionesByPeliculaId(int.Parse(peliculaId))) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 404 };
            }

        }

        [Route("funcionesUnicas")]
        [HttpGet]
        public IActionResult GetFuncionesUnicasByPeliculaId(string peliculaId)
        {
            var response = _service.ValidadorFuncionByPeliculaId(peliculaId);

            if (response.IsValid)
            {
                return new JsonResult(_service.FuncionesByPeliculaId(int.Parse(peliculaId))) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }

        }

        [Route("{id}/tickets")]
        [HttpGet]
        public IActionResult GetTicketsAvailabilityByFuncionId(string id)
        {
            var response = _service.ValidadorFuncionById(id);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetTicketsAvailabilityByFuncionId(int.Parse(id))) { StatusCode = 200 };
            }
            else
            {
                string DevolverErrores = "";
                foreach (var error in response.Errors)
                {
                    DevolverErrores += error;
                }
                return new JsonResult(DevolverErrores) { StatusCode = 400 };
            }

        }

        [Route("funcionId")]
        [HttpGet]
        public IActionResult GetFuncionId(string fecha, string horario, int peliculaId, int salaId)
        {
            return new JsonResult(_service.GetFuncionId(fecha, horario, peliculaId, salaId)) { StatusCode = 200 };
        }

        [Route("funcionId2")]
        [HttpGet]
        public IActionResult GetFuncionId2(string fecha, string horario, int peliculaId, int salaId)
        {
            return new JsonResult(_service.GetFuncionId2(fecha, horario, peliculaId, salaId)) { StatusCode = 200 };
        }
    }
}
