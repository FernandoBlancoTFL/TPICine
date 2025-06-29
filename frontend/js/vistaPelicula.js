const contenedorPeliculas = document.querySelector('.content__main_grid-items');
const item1 = document.querySelector('.content__main_grid-items2 #item1');
const item2 = document.querySelector('.content__main_grid-items2 #item2');
const item3 = document.querySelector('.content__main_grid-items2 #item3');
const item4 = document.querySelector('.content__main_grid-items2 #item4');

const url = 'https://localhost:44384/api/pelicula/';
const urlFuncionPelicula = 'https://localhost:44384/api/funcion/funcionesUnicas?peliculaId=';
const urlFechaHorarios = 'https://localhost:44384/api/funcion/peliculas/horarios?id=';
const urlFuncionId = 'https://localhost:44384/api/funcion/funcionId?fecha=';
const urlFuncionId2 = 'https://localhost:44384/api/funcion/funcionId2?fecha=';
const urlTickets = 'https://localhost:44384/api/ticket';
const urlDisponibilidadTickets = 'https://localhost:44384/api/ticket/capacidadSala?funcionId=';

window.onload = () => {
    obtenerLocalStorage();
    busquedaNav();
}

function obtenerLocalStorage(){
    let peliculaId = localStorage.getItem("peliculaId");
    traerPelicula(peliculaId);
    traerFuncionPelicula(peliculaId);
}

function busquedaNav() {
    let newDiv = document.createElement("div");
    newDiv.id = "headerDiv";

    let inputTitulo = document.createElement("input");
    inputTitulo.id = "headerInput";
    inputTitulo.setAttribute("maxlength","31");
    inputTitulo.placeholder = "Buscar Película";

    let inputFecha = document.createElement("input");
    inputFecha.id = "headerInput2";
    inputFecha.type = "date";
    
    let ButtonA = document.createElement("a");
    ButtonA.id = "headerBtn";
    ButtonA.href = "vistaResultadoBusqueda.html";

    let ButtonSearch = document.createElement("button");
    ButtonSearch.id = "headerBtnSearch";
    ButtonSearch.appendChild(document.createTextNode("Buscar"));
    ButtonSearch.addEventListener("click", function(e){
        guardarLocalStorageFecha(inputFecha.value);
        guardarLocalStorageTitulo(inputTitulo.value);
    },false);

    ButtonA.appendChild(ButtonSearch);

    newDiv.appendChild(inputTitulo);
    newDiv.appendChild(inputFecha);
    newDiv.appendChild(ButtonA);

    let header = document.getElementById("headerId");
    header.appendChild(newDiv);
}

function guardarLocalStorageFecha(fecha){
    localStorage.setItem("fecha", fecha);
}

function guardarLocalStorageTitulo(titulo){
    localStorage.setItem("titulo", titulo);
}

function traerPelicula(idPelicula){
    fetch(url + idPelicula)
    .then(response => response.json())
    .then(response => {

        item1.innerHTML += `
            <h1 id="peliculaTitulo">${response.titulo}</h1>
        `;

        item2.innerHTML += `
            <div id="peliculaDatos">
                <img id="peliculaPoster" src="${response.poster}" >
                <h1 id="peliculaSinopsis">Sinopsis:<br>${response.sinopsis}</h1>
            </div>
        `;

        item3.innerHTML += `
            <div id="peliculaTrailerDiv">${response.trailer}</div>
            <div id="promoDiv">
                <img src="imagenes/la_nacion_promo.PNG" alt="">
                <img src="imagenes/50_off.PNG" alt="">
            </div>
        `;
    })
    .catch(err => console.log(err));
}

function traerFuncionPelicula(idPelicula){
    fetch(urlFuncionPelicula + idPelicula)
    .then(response => response.json())
    .then(response => {
        if(response.length == 0){
            console.log("no hay funciones asignadas para esta película");
            let mensaje = document.createElement("h3");
            mensaje.id = "mensajeErrorFuncion";
            mensaje.appendChild(document.createTextNode("No hay funciones registradas para esta película."));

            let button = document.createElement("button");
            button.id = "botonFuncionError";
            button.className = "btn btn-primary";
            button.appendChild(document.createTextNode("Volver al Inicio"));
            let a = document.createElement("a");
            a.href = "index.html";
            a.appendChild(button);

            let txt = document.createElement("h1");
            let txt2 = document.createElement("h1");

            alert("Le informamos que no hay funciones registradas para esta película.");
            let mensajeContainer = document.getElementById("item4");
            mensajeContainer.appendChild(mensaje);
            mensajeContainer.appendChild(txt);
            mensajeContainer.appendChild(txt2);
            mensajeContainer.appendChild(a);
        }
        else{
            let newDiv = document.createElement("div");
            newDiv.id = "FechaFuncionesTitulo";
            let newContent = document.createTextNode("Seleccione el día:");
            newDiv.appendChild(newContent);

            let newDiv2 = document.createElement("div");
            newDiv2.id = "FechaFuncionesBtn";

            let TituloHorarios = document.createElement("div");
            TituloHorarios.id = "FechaHorariosTitulo";
            let Content = document.createTextNode("Seleccione el horario:");
            TituloHorarios.appendChild(Content);

            let newDiv3 = document.createElement("div");
            newDiv3.id = "FechaHorariosBtn";

            response.forEach(funcion => {
                let Button = document.createElement("button");
                Button.id = "botonFuncion";
                Button.className = "btn btn-primary";
                let newContentButton = document.createTextNode(funcion.fecha);
                Button.appendChild(newContentButton);
                Button.addEventListener("click", function(e){
                    traerHorarios(idPelicula, funcion, TituloHorarios , newDiv3);
                },false);
        
                newDiv2.appendChild(Button);
        
                let currentDiv = document.getElementById("item4");
                currentDiv.appendChild(newDiv);
                currentDiv.appendChild(newDiv2);
            });
        }
    })
    .catch(err => console.log(err));    
}

function traerHorarios(idPelicula, funcion, TituloHorarios, newDiv){
    fetch(urlFechaHorarios + idPelicula + '&fecha=' + funcion.fecha)
    .then(response => response.json())
    .then(response => {

        let currentDiv = document.getElementById("item4");
        currentDiv.appendChild(TituloHorarios);
        currentDiv.appendChild(newDiv);
        let currentDiv2 = document.getElementById("FechaHorariosBtn");
        var div = document.getElementById('FechaHorariosBtn');
        while (div.firstChild) {
            div.removeChild(div.firstChild);
        }

        response.forEach(funcion => {
            let Button2 = document.createElement("button");
            Button2.className = 'btn btn-primary';
            Button2.id = "botonFuncion";
            Button2.setAttribute("data-bs-toggle", "modal");
            Button2.setAttribute("data-bs-target", "#exampleModal");
            let newContentButton = document.createTextNode(funcion.horario + "hs");
            Button2.appendChild(newContentButton);
            Button2.addEventListener("click", function(e){
                avisoCapacidadSala(funcion);
                modal(funcion);
            },false);
            
            currentDiv2.appendChild(Button2);
        });
        
    })
    .catch(err => console.log(err));
}

function avisoCapacidadSala(funcionActual) {
    let mensaje = document.getElementById("cantidadTicketsAviso");

    fetch(urlFuncionId + funcionActual.fecha + '&horario=' + funcionActual.horario + '&peliculaId=' + funcionActual.peliculaId + '&salaId=' + funcionActual.salaId)
    .then(response => response.json())
    .then(response => {
        fetch(urlDisponibilidadTickets + response)
        .then(response2 => response2.json())
        .then(response2 => {
            mensaje.innerHTML = `Ingrese la cantidad de tickets a comprar (${response2} Tickets disponibles):`;
        })
        .catch(err => console.log(err));
    })
    .catch(err => console.log(err));
}

function modal(funcion){
    let usuario = document.getElementById("nombreUsuario");
    let cantidadTickets = document.getElementById("cantidadTicket");
    let botonCompra = document.getElementById("crearTicketBtn");
    botonCompra.setAttribute("data-bs-toggle", "modal");
    botonCompra.setAttribute("data-bs-target", "#ModalCompraRealizada");

    botonCompra.addEventListener("click", function(e){
        createTicket(usuario.value, cantidadTickets.valueAsNumber, funcion.fecha, funcion.horario, funcion.peliculaId, funcion.salaId);
        var div = document.getElementById('item4');
        while (div.firstChild) {
            div.removeChild(div.firstChild);
        }
        traerFuncionPelicula(localStorage.getItem("peliculaId"));
        modalComprobanteCompra(funcion, usuario.value);
    },false);

    const btnCerrar = document.getElementById("btnCerrar");
    btnCerrar.addEventListener("click", function(e){
        recargarPagina();
    },false);
    const btnCerrar2 = document.getElementById("btnCerrar2");
    btnCerrar2.addEventListener("click", function(e){
        recargarPagina();
    },false);
}

function createTicket(usuario, cantidadTickets, funcionFecha, funcionHorario, funcionPelicula, funcionSala){
    const modalError = document.getElementById("modal-bodyId");
    const modalError2 = document.getElementById("modal-titleId");

    fetch(urlFuncionId + funcionFecha + '&horario=' + funcionHorario + '&peliculaId=' + funcionPelicula + '&salaId=' + funcionSala)
    .then(response => response.json())
    .then(response => {
        fetch(urlTickets, {
            method : "POST",
            body : JSON.stringify({
                "funcionId" : response,
                "usuario" : usuario,
                "cantidad" : cantidadTickets
            }),
            headers: {"Content-type" : "application/json"}
        })
        .then(response => response.json())
        .then(response => {
            console.log(response);
            if(response == "La sala no tiene espacio, no se puede registrar tickets"){
                modalError2.innerHTML = `Error en la compra`;
                modalError.innerHTML = `No se puede comprar mas películas porque no hay espacio suficiente en la sala`;
            }
        })
        .catch(err => console.log(err));
    })
    .catch(err => console.log(err));
}

function modalComprobanteCompra(funcion, usuario){

    const modalTitulo = document.getElementById("titulo");
    const modalFecha = document.getElementById("fecha");
    const modalHorario = document.getElementById("hora");
    const modalUsuario = document.getElementById("user");
    const btnCerrar = document.getElementById("btnCerrar3");
    btnCerrar.addEventListener("click", function(e){
        recargarPagina();
    },false);
    const btnCerrar2 = document.getElementById("btnCerrar4");
    btnCerrar2.addEventListener("click", function(e){
        recargarPagina();
    },false);

    fetch(url + localStorage.getItem("peliculaId"))
    .then(response => response.json())
    .then(response => {
        modalTitulo.innerHTML = "Película: " + response.titulo;
        modalFecha.innerHTML = "Fecha: " + funcion.fecha;
        modalHorario.innerHTML = "Horario: " + funcion.horario + "hs";
        modalUsuario.innerHTML = "Usuario: " + usuario;
    })
    .catch(err => console.log(err));
}

function recargarPagina() {
    window.location.href = "vistaPelicula.html";
}

function click(){
    alert("Ticket creado");
}
