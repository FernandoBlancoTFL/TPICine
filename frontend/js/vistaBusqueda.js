const urlPeliculas = 'https://localhost:44384/api/pelicula/peliculas';
const urlBusqueda = 'https://localhost:44384/api/funcion/buscador?fecha=';

const contenedorPeliculas = document.querySelector('.content__main_grid-items');

window.onload = () => {
    busquedaNav();
    traerPelicula(urlBusqueda);
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

function borrarContenido(cadena) {
    var div = document.getElementById(cadena);
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
}

function traerPelicula(url){
    let fecha = localStorage.getItem("fecha");
    let titulo = localStorage.getItem("titulo");

    let mensajeResultado = document.createElement("h1");
    mensajeResultado.id = "MensajeResultadoId";
    mensajeResultado.appendChild(document.createTextNode("Resultados de la búsqueda:"));

    let button = document.createElement("button");
    button.id = "botonFuncionError";
    button.className = "btn btn-primary";
    button.appendChild(document.createTextNode("Volver al Inicio"));
    let a = document.createElement("a");
    a.href = "index.html";
    a.appendChild(button);

    let imagen = document.createElement("img");
    imagen.id = "imgError";
    imagen.src = "/imagenes/no_encontrado.PNG";

    let mensajeContainer = document.getElementById("idContainer");

    fetch(url + fecha + "&titulo=" + titulo)
    .then(response => response.json())
    .then(response => {
        if(typeof(response) == "string"){
            borrarContenido("idContainer");

            let mensaje = document.createElement("h1");
            mensaje.id = "mensajeErr";
            mensaje.appendChild(document.createTextNode(response));

            mensajeContainer.appendChild(mensajeResultado);
            mensajeContainer.appendChild(imagen);
            mensajeContainer.appendChild(mensaje);
            mensajeContainer.appendChild(a);
        }
        else{
            if(response.length == 0){
                borrarContenido("idContainer");
                let mensaje = document.createElement("h1");
                mensaje.id = "mensajeErr";
                mensaje.appendChild(document.createTextNode("Disculpe las molestias, no hay funciones registradas para el día de hoy."));

                mensajeContainer.appendChild(mensajeResultado);
                mensajeContainer.appendChild(imagen);
                mensajeContainer.appendChild(mensaje);
                mensajeContainer.appendChild(a);
            }
            if(response.length <= 4){
                contenedorPeliculas.id = "content__main_grid-itemsId";
            }
            response.forEach(pelicula => {
                const newDiv = document.createElement("div");
                newDiv.id = "divPelículas";

                const newText = document.createElement("p");
                newText.appendChild(document.createTextNode(pelicula.titulo));

                const newImage = document.createElement("img");
                newImage.src = pelicula.poster;
                newImage.title = pelicula.titulo;
                newImage.id = "peliculaImagen";

                const newLink = document.createElement("a");
                newLink.id = "pelicula";
                newLink.href = "vistaPelicula.html";
                newLink.addEventListener("click", function(e){
                    guardarLocalStorage(pelicula);
                },false);
        
                newLink.appendChild(newImage);
                newDiv.appendChild(newLink);
                newDiv.appendChild(newText);
                contenedorPeliculas.appendChild(newDiv);
            });
        }
        
    })
    .catch(err => console.log(err));
}

function guardarLocalStorage(pelicula){
    localStorage.setItem("peliculaId", pelicula.peliculaId);
}

function guardarLocalStorageFecha(fecha){
    localStorage.setItem("fecha", fecha);
}

function guardarLocalStorageTitulo(titulo){
    localStorage.setItem("titulo", titulo);
}