using Application.InterfaceService;
using Domain;
using Domain.Commands;
using Domain.DTOs;
using Domain.DTOs.FuncionDTOs;
using Domain.DTOs.PeliculaDTOs;
using Domain.Entities;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly IGenericsRepository _repository;
        private readonly IQueryGeneric _queryGeneric;
        private readonly IQueryFuncion _queryFuncion;
        private readonly IQuerySala _querySala;
        private readonly IQueryPelicula _queryPelicula;
        private readonly ITicketService _ticketService;

        public FuncionService(IGenericsRepository repository, IQueryGeneric queryGeneric, IQueryFuncion queryFuncion, IQuerySala querySala, IQueryPelicula queryPelicula, ITicketService ticketService)
        {
            _repository = repository;
            _queryGeneric = queryGeneric;
            _queryFuncion = queryFuncion;
            _querySala = querySala;
            _queryPelicula = queryPelicula;
            _ticketService = ticketService;
        }
        
        public List<ResponseAllFunciones> GetAllFunciones(string fecha, string titulo)
        {
            List<ResponseAllFunciones> ListaResponseFunciones = new List<ResponseAllFunciones>();

            var funciones = _queryFuncion.GetFuncionesByFechaActual(fecha);
            var peliculas = _queryPelicula.GetPeliculasByTitulo(titulo);
            var fechaFunciones = _queryFuncion.GetFuncionesByFecha(fecha);

            if (fecha != null || titulo != null){
                foreach (var pelicula in peliculas)
                {
                    foreach (var funcion in fechaFunciones)
                    {
                        if (funcion.PeliculaId == pelicula.PeliculaId)
                        {
                            ListaResponseFunciones.Add(funcion);
                        }
                    }
                }
            }
            else
                return funciones;

            return ListaResponseFunciones;
        }

        //tengo que hacer un método que agarre la lista y convierta el horario de DateTime a string (probablemente tenga que hacer un nuevo endpoint)
        public List<FuncionDto> GetAllHorarioFunciones(int peliculaId, string fecha)
        {
            //obtengo lista de peliculas para obtener título
            var pelicula = _queryPelicula.GetPeliculaByIdQuery(peliculaId);

            List<ResponseAllFunciones> listaFunciones = GetAllFunciones(fecha, pelicula.Titulo);
            List<FuncionDto> listaFuncionesHorario = new List<FuncionDto>();

            foreach (var funcion in listaFunciones)
            {
                string[] HorarioString = funcion.Horario.ToString().Split(':');
                string horario = HorarioString[0] + ":" + HorarioString[1];

                if (GetFuncionId2(funcion.Fecha.ToShortDateString(), funcion.Horario.ToString(), funcion.PeliculaId, funcion.SalaId))
                {
                    var entity = new FuncionDto
                    {
                        Fecha = funcion.Fecha.ToShortDateString(),
                        Horario = horario,
                        PeliculaId = funcion.PeliculaId,
                        SalaId = funcion.SalaId
                    };

                    listaFuncionesHorario.Add(entity);
                }
            }

            return listaFuncionesHorario;
        }

        //devuelve las pelis de las funciones sin repetir
        public IEnumerable<ResponseGetPeliculas> GetAllPeliculasFunciones(string fecha, string titulo)
        {
            fecha = "";
            titulo = "";

            List<ResponseGetPeliculas> ListaPeliculas = new List<ResponseGetPeliculas>();
            List<ResponseGetPeliculas> ListaPeliculasSinRepetir = new List<ResponseGetPeliculas>();

            var funciones = _queryFuncion.GetFuncionesByFechaHoy(fecha);

            //var funciones = _queryFuncion.GetFuncionesByFechaActual(fecha); //trae las funciones del dia de hoy para delante
            var peliculas = _queryPelicula.GetPeliculasByTitulo2(titulo); //trae todas las pelis con ese título
            var fechaFunciones = _queryFuncion.GetFuncionesByFecha(fecha); //trae todas las funciones de una fecha determinada o todas las funciones si no se ingresa fecha

            foreach (var funcion in funciones)
            {
                foreach (var pelicula in peliculas)
                {
                    if (pelicula.PeliculaId == funcion.PeliculaId)
                    {
                        ListaPeliculas.Add(pelicula);
                    }

                }
            }

            IEnumerable<ResponseGetPeliculas> peliculasNoDuplicadas = ListaPeliculas.Distinct();

            return peliculasNoDuplicadas;
        }

        public IEnumerable<ResponseGetPeliculas> GetAllPeliculasFuncionesBusqueda(string fecha, string titulo)
        {
            if (fecha == null && titulo == null)
            {
                return GetAllPeliculasFunciones(fecha, titulo);
            }
            else
            {
                List<ResponseGetPeliculas> ListaPeliculas = new List<ResponseGetPeliculas>();

                var peliculas = _queryPelicula.GetPeliculasByTitulo2(titulo);
                var fechaFunciones = _queryFuncion.GetFuncionesByFecha(fecha);

                foreach (var funcion in fechaFunciones)
                {
                    foreach (var pelicula in peliculas)
                    {
                        if (pelicula.PeliculaId == funcion.PeliculaId)
                        {
                            ListaPeliculas.Add(pelicula);
                        }

                    }
                }

                IEnumerable<ResponseGetPeliculas> peliculasNoDuplicadas = ListaPeliculas.Distinct();

                return peliculasNoDuplicadas;
            }
        }

        public CustomResponse<ResponseAllFunciones> ValidadorFuncionesActuales(IEnumerable<ResponseGetPeliculas> lista)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            List<ResponseGetPeliculas> ListaPeliculas = new List<ResponseGetPeliculas>();

            if (lista.Count() == 0)
            {
                response.Errors.Add("Disculpe las molestias, no hay funciones registradas para el día de hoy");
            }
            return response;
        }

        public FuncionDto CreateFuncion(FuncionDto funcion)
        {
            string[] FechaString = funcion.Fecha.Split('/');
            DateTime FechaDateTime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));

            string[] HoraString = funcion.Horario.Split(':');
            TimeSpan HoraTimeSpan = new TimeSpan(int.Parse(HoraString[0]), int.Parse(HoraString[1]), 0);

            var entity = new Funcion
            {
                Fecha = FechaDateTime,
                Horario = HoraTimeSpan,
                PeliculaId = funcion.PeliculaId,
                SalaId = funcion.SalaId
            };

            _repository.Add(entity);

            return new FuncionDto { Fecha = entity.Fecha.ToShortDateString().ToString(), Horario = entity.Horario.ToString(), PeliculaId = entity.PeliculaId, SalaId = entity.SalaId };
        }
        
        public ResponseAllFunciones DeleteFuncion(int id)
        {
            var funcionDelete = _queryFuncion.GetFuncionByIdQuery(id);
            _repository.Delete<Funcion>(id);
            return funcionDelete;
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorDelete(string funcionId)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            int fId;
            bool resultado = int.TryParse(funcionId, out fId);

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
                    var funcion = _queryFuncion.GetFuncionByIdQuery(fId);
                    response.Data = funcion;
                }
                else
                    response.Errors.Add("No hay una función registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de función");

            return response;
        }
        
        public List<FuncionDto> GetFuncionesByPeliculaId(int PeliculaId)
        {
            List<FuncionDto> ListaFuncionesResponse = new List<FuncionDto>();
            var ListaFunciones = _queryGeneric.GetAll<Funcion>();

            foreach (var funcion in ListaFunciones)
            {
                if (funcion.PeliculaId == PeliculaId)
                {
                    ListaFuncionesResponse.Add(new FuncionDto
                    {
                        PeliculaId = funcion.PeliculaId,
                        SalaId = funcion.SalaId,
                        Fecha = funcion.Fecha.ToShortDateString(),
                        Horario = funcion.Horario.ToString()
                    });
                }
            }
            return ListaFuncionesResponse;
        }
        //devuelve las funciones sin repetir
        public List<FuncionDto> FuncionesByPeliculaId(int PeliculaId)
        {
            string fecha = "";
            List<FuncionDto> ListaFuncionesResponse = new List<FuncionDto>();
            var ListaFunciones = _queryFuncion.GetFuncionesByFechaActual(fecha);
            List<FuncionDto> ListaFuncionesDiasRecientes = new List<FuncionDto>();

            foreach (var funcion in ListaFunciones)
            {
                if (funcion.PeliculaId == PeliculaId)
                {
                    if(GetFuncionId2(funcion.Fecha.ToShortDateString(), funcion.Horario.ToString(), funcion.PeliculaId, funcion.SalaId))
                    {
                        ListaFuncionesResponse.Add(new FuncionDto
                        {
                            PeliculaId = funcion.PeliculaId,
                            SalaId = funcion.SalaId,
                            Fecha = funcion.Fecha.ToShortDateString(),
                            Horario = funcion.Horario.ToString()
                        });
                    }
                }
            }
            
            var DistinctItems = ListaFuncionesResponse.GroupBy(x => x.Fecha).Select(y => y.First()).ToList();
            
            if (DistinctItems.Count > 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    ListaFuncionesDiasRecientes.Add(DistinctItems[i]);
                }
                return ListaFuncionesDiasRecientes;
            }

            return DistinctItems;
        }

        public int GetTicketsAvailabilityByFuncionId(int funcionId)
        {
            return _ticketService.TicketsDisponibles(funcionId);
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorFuncionFechaTitulo(string fecha, string titulo)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            bool resultado = true;
            if (fecha != null)
            {
                DateTime dt;
                resultado = DateTime.TryParse(fecha, out dt);

                if (resultado)
                {
                    var listaFunciones = _queryGeneric.GetAll<Funcion>();
                    listaFunciones.ForEach(funcion =>
                    {
                        if (dt == funcion.Fecha)
                        {
                            resultado = false;
                        }
                    });

                    if (!resultado)
                    {
                        var funciones = GetAllFuncionesByTitulo(titulo);
                        if (funciones.Count != 0)
                        {
                            response.Data2 = funciones;
                        }
                        else
                            response.Errors.Add("No hay una función registrada con ese titulo de película");
                    }
                    else
                        response.Errors.Add("No hay una funcion registrada para la fecha ingresada(" + fecha + ").");
                }
                else
                    response.Errors.Add("Ingresó un formato de fecha incorrecta, por favor ingrese nuevamente con el formato correcto (YYYY/MM/DD)");
            }
            else
            {
                if(titulo != null)
                {
                    var funciones = GetAllFuncionesByTitulo(titulo);
                    if (funciones.Count != 0)
                    {
                        response.Data2 = funciones;
                    }
                    else
                        response.Errors.Add("No hay una función registrada con el título: " + titulo);
                }
            }
            return response;
        }

        public List<ResponseAllFunciones> GetAllFuncionesByTitulo(string Titulo)
        {
            return _queryFuncion.GetAllFuncionesByPeliculaTitulo(Titulo);
        }
        
        public CustomResponse<FuncionDto> ValidadorFuncion(FuncionDto funcion)
        {
            var ventanaDeTiempoFuncion = new TimeSpan(02, 30, 0);
            var response = new CustomResponse<FuncionDto>();
            int pId, sId;
            bool resultado = int.TryParse(funcion.PeliculaId.ToString(), out pId);

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
                    resultado = int.TryParse(funcion.SalaId.ToString(), out sId);
                    if (resultado)
                    {
                        var listaSalas = _queryGeneric.GetAll<Sala>();
                        listaSalas.ForEach(sala =>
                        {
                            if (sId == sala.SalaId)
                            {
                                resultado = false;
                            }
                        });

                        if (!resultado)
                        {
                            DateTime dt;
                            resultado = DateTime.TryParse(funcion.Fecha, out dt);

                            if (resultado)
                            {
                                TimeSpan ts;
                                resultado = TimeSpan.TryParse(funcion.Horario, out ts);
                                if (resultado)
                                {
                                    var listaFunciones = _queryFuncion.getFuncionesByDateAndSala(funcion.Fecha, funcion.SalaId);
                                    if (listaFunciones.Count == 0)
                                    {
                                        response.Data = funcion;
                                    }
                                    else
                                    {
                                        listaFunciones.ForEach(funcionLista =>
                                        {
                                            if (ts >= funcionLista.Horario && ts <= funcionLista.Horario.Add(ventanaDeTiempoFuncion))
                                            {
                                                response.Errors.Add("No se puede registrar porque ya hay una función registrada en ese horario");
                                            }
                                            else
                                            {
                                                response.Data = funcion;
                                            }
                                        });
                                    }
                                }
                                else
                                    response.Errors.Add("Ingresó un formato de horario incorrecto, por favor ingrese nuevamente con el formato correcto (HH:MM)");
                            }
                            else
                                response.Errors.Add("Ingresó un formato de fecha incorrecta, por favor ingrese nuevamente con el formato correcto (YYYY/MM/DD)");

                        }
                        else
                            response.Errors.Add("No hay una sala registrada con ese id");

                    }
                    else
                        response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de sala");
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de pelicula");

            return response;
        }
        
        public CustomResponse<ResponseGetPeliculas> ValidadorFuncionByPeliculaId(string peliculaId)
        {
            var response = new CustomResponse<ResponseGetPeliculas>();
            int pId;
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
                    var pelicula = _queryPelicula.GetPeliculaByIdQuery(pId);
                    response.Data = pelicula;
                }
                else
                    response.Errors.Add("No hay una película registrada con ese id");
            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de pelicula");

            return response;
        }
        
        public CustomResponse<ResponseAllFunciones> ValidadorFuncionById(string funcionId)
        {
            var response = new CustomResponse<ResponseAllFunciones>();
            int fId;
            bool resultado = int.TryParse(funcionId, out fId);

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
                    var funcion = _queryFuncion.GetFuncionByIdQuery(fId);
                    response.Data = funcion;
                }
                else
                    response.Errors.Add("No hay una función registrada con ese id");

            }
            else
                response.Errors.Add("Ingresó un dato incorrecto, por favor ingrese un número de id de función");
            return response;
        }

        public int GetFuncionId(string fecha, string horario, int peliculaId, int salaId)
        {
            return _queryFuncion.GetFuncionId(fecha, horario, peliculaId, salaId);
        }

        public bool GetFuncionId2(string fecha, string horario, int peliculaId, int salaId)
        {
            var funcionId = _queryFuncion.GetFuncionId(fecha, horario, peliculaId, salaId);
            return CapacidadSala(funcionId);
        }

        public bool CapacidadSala(int funcionId)
        {
            var funcion = _queryFuncion.GetFuncionByIdQuery(funcionId);

            var sala = _querySala.GetSalaByIdQuery(funcion.SalaId);

            var ticketss = _ticketService.GetTicketsByFuncionId(funcionId);

            var tickesDisponibles = sala.Capacidad - ticketss.Count();

            if (tickesDisponibles == 0)
            {
                return false;
            }
            else
                return true;
        }

    }
}
