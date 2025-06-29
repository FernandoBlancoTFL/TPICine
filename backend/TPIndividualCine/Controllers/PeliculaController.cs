using Application.InterfaceService;
using Domain.DTOs.PeliculaDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TPIndividualCine.Controllers
{
    [Route("api/pelicula")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetPeliculaById(string id)
        {
            var response = _service.ValidadorPeliculaId(id);

            if (response.IsValid)
            {
                return new JsonResult(_service.GetPeliculaById(int.Parse(id))) { StatusCode = 200 };
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

        [Route("peliculas")]
        [HttpGet]
        public IActionResult GetPeliculas()
        {
            return new JsonResult(_service.GetPeliculas()) { StatusCode = 200 };
        }

        [HttpPut("{id}")]
        public IActionResult Put(ResponseUpdatePelicula pelicula, int id)
        {
            var response = _service.ValidadorUpdate(id.ToString());

            if (response.IsValid)
            {
                return new JsonResult(_service.UpdatePelicula(pelicula, id)) { StatusCode = 200 };
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
    }
}
