const urlFunciones = 'https://localhost:44384/api/funcion/peliculas';
const urlPeliculas = 'https://localhost:44384/api/pelicula/peliculas';
const contenedorPeliculas = document.querySelector('.content__main_grid-items');
const mensajeError = document.querySelector('#carteleraId');
const cuadroBusqueda = document.querySelector('#cuadroBusqueda');

window.onload = () => {
    traerPelicula(urlPeliculas);
    traerMenuBusqueda();
    busquedaNav();
    redericcionBanner();
}

function redericcionBanner() {
    const banner = document.querySelector('#banner');
    banner.addEventListener("click", function(e){
        guardarLocalStorage2(18);
        window.location.href = "vistaPelicula.html";
    },false);

    const banner2 = document.querySelector('#banner2');
    banner2.addEventListener("click", function(e){
        guardarLocalStorage2(2);
        window.location.href = "vistaPelicula.html";
    },false);

    const banner3 = document.querySelector('#banner3');
    banner3.addEventListener("click", function(e){
        guardarLocalStorage2(5);
        window.location.href = "vistaPelicula.html";
    },false);

    const banner4 = document.querySelector('#banner4');
    banner4.addEventListener("click", function(e){
        guardarLocalStorage2(3);
        window.location.href = "vistaPelicula.html";
    },false);
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

function traerMenuBusqueda() {
    let Button = document.createElement("button");
    Button.id = "botonBusqueda";
    let newContentButton = document.createTextNode("Todas las películas");
    Button.appendChild(newContentButton);
    Button.addEventListener("click", function(e){
        window.location.href = "/index.html";
    },false);

    let newDiv = document.getElementById("cuadroBusqueda");
    newDiv.appendChild(Button);

    let Button2 = document.createElement("button");
    Button2.id = "botonBusqueda";
    let newContentButton2 = document.createTextNode("Funciones de hoy");
    Button2.appendChild(newContentButton2);
    Button2.addEventListener("click", function(e){
        borrarContenido('divPeliculas');
        traerPelicula(urlFunciones);
    },false);

    newDiv.appendChild(Button2);
}

function borrarContenido(cadena) {
    var div = document.getElementById(cadena);
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
}

function traerPelicula(url){
    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(typeof(response) == "string"){
            borrarContenido('imagenesVistaPrincipal');
            borrarContenido('imagenesVistaPrincipal2');
            mensajeError.innerHTML = `
                <p>${response}</p>
            `;
        }
        if(response.length <= 4){
            contenedorPeliculas.id = "content__main_grid-itemsId";

            const imagenLateral = document.querySelector('#imagenesVistaPrincipal');
            const imagenLateral2 = document.querySelector('#imagenesVistaPrincipal2');
            imagenLateral.id = "imagenesDiv";
            imagenLateral2.id = "imagenesDiv";
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
        
    })
    .catch(err => console.log(err));
}

function guardarLocalStorage(pelicula){
    localStorage.setItem("peliculaId", pelicula.peliculaId);
}

function guardarLocalStorage2(peliculaId){
    localStorage.setItem("peliculaId", peliculaId);
}

function guardarLocalStorageFecha(fecha){
    localStorage.setItem("fecha", fecha);
}

function guardarLocalStorageTitulo(titulo){
    localStorage.setItem("titulo", titulo);
}




