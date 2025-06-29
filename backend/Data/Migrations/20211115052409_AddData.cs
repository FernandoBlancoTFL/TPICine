using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/fast-and-furious-9-poster-1580411801.jpeg?crop=1xw:1xh;center,top&resize=980:*", "Dom Toretto lleva una vida tranquila con Letty y su hijo, el pequeño Brian, pero saben que el peligro siempre acecha. Su equipo pronto se une para detener un complot trascendental del asesino más hábil y el conductor de alto rendimiento el hermano de Dom.", "Rápidos y furiosos 9", "<iframe width='660' height='315' src='https://www.youtube.com/embed/ElLP7HAwUAw' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 20, "https://pics.filmaffinity.com/venom_let_there_be_carnage-797643212-large.jpg", "Regresa Eddie Brock y su Venom. Que en esta oportunidad se reencontrará con Cletus Cassady,el enemigo más sangriento de la historia de Spiderman a quién se lo conoce como “Carnage”.", "Venom: Carnage Liberado", "<iframe width='660' height='315' src='https://www.youtube.com/embed/F4Ygcigj0Gk' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 19, "https://static.cinemarkhoyts.com.ar/Images/Posters/1fa377f4d4d78239363a228dd91ea241.jpg?v=01112021", "Chernobyl es el primer largometraje ruso importante sobre las consecuencias de la explosión en la central nuclear de Chernobyl, cuando cientos de personas sacrificaron sus vidas para limpiar el lugar de la catástrofe.", "Chernóbil: La Película", "<iframe width='660' height='315' src='https://www.youtube.com/embed/9DkXQM3eR8I' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 18, "https://images.clarin.com/2021/04/16/el-primer-afiche-que-se___8xbNrbH6m_720x0__1.jpg", "Los Eternos, una raza de seres inmortales con poderes sobrehumanos que han vivido en secreto en la Tierra durante miles de años, se reúnen para luchar contra los malvados Deviants.", "Eternals", "<iframe width='660' height='315' src='https://www.youtube.com/embed/v1EkoQV4g5c' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 17, "https://image.tmdb.org/t/p/original//hKZHk6I1p58ZeXbwjQok7DSWfZ.jpg", "Una joven desesperada recurre a una clínica que hace abortos clandestinos. Al descubrir que está en su cuarto mes de embarazo, la doctora se niega, pero le propone vender el bebé a unos clientes suyos.", "El Apego", "<iframe width='660' height='315' src='https://www.youtube.com/embed/80P35D4vyHg' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 16, "https://static.cinemarkhoyts.com.ar/Images/Posters/3fc8caad36d4f72651d8068bfa039110.jpg?v=08112021", "Una Alerta Roja emitida por Interpol es una alerta global para cazar y capturar a los más buscados del mundo. Pero cuando un atrevido atraco reúne al principal agente del FBI (Johnson) y dos criminales rivales (Gadot, Reynolds), no se sabe qué sucederá.", "Alerta roja", "<iframe width='660' height='315' src='https://www.youtube.com/embed/FojI-_1hST4' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 15, "https://pics.filmaffinity.com/the_unholy-403969644-large.jpg", "Un periodista en horas bajas descubre una serie de aparentes milagros de una joven que dice haber sido visitada por la Virgen María, milagros acaecidos en un pequeño pueblo de Nueva Inglaterra.", "Ruega por nosotros", "<iframe width='660' height='315' src='https://www.youtube.com/embed/a_BYIlWcbVg' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 14, "https://pics.filmaffinity.com/nobody-390795243-large.jpg", "Hutch Mansell no se defiende cuando dos ladrones irrumpen en su casa. En un aluvión de puños, disparos y chirridos de neumáticos, Hutch ahora debe salvar a su esposa e hijo de un adversario peligroso y asegurarse de que nunca más lo subestimen.", "Nadie", "<iframe width='660' height='315' src='https://www.youtube.com/embed/Mzrib73dVbc' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 13, "https://pics.filmaffinity.com/paw_patrol_the_movie-626479283-large.jpg", "La Patrulla Canina está en racha. Cuando Humdinger, su mayor rival, se convierte en alcalde de la cercana Ciudad Aventura y empieza a causar estragos, Ryder y los heroicos cachorros se ponen en marcha para enfrentarse a este nuevo desafío.", "La Patrulla Canina: La película", "<iframe width='660' height='315' src='https://www.youtube.com/embed/ABjdw_caRsQ' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 11, "https://pics.filmaffinity.com/godzilla_vs_kong-370227109-large.jpg", "Godzilla y Kong, dos de las fuerzas más poderosas de un planeta habitado por todo tipo de aterradoras criaturas, se enfrentan en un espectacular combate que sacude los cimientos de la humanidad.", "Godzilla vs. Kong", "<iframe width='660' height='315' src='https://www.youtube.com/embed/Kqg8zLgESyQ' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 12, "https://image.tmdb.org/t/p/original//i6E8fx8lAEI0PGGCUlaA2Ap1gWi.jpg", "La superestrella LeBron James y su hijo pequeño, Dom, quedan atrapados en el espacio digital por una IA rebelde. LeBron se une a Bugs Bunny, Daffy Duck y el resto de la pandilla Looney Tunes para un juego de baloncesto de alto riesgo.", "Space Jam: una nueva era", "<iframe width='660' height='315' src='https://www.youtube.com/embed/8GltZA7F7-M' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 9, "https://m.media-amazon.com/images/I/51sWzqfPYEL._AC_.jpg", "En la conclusión de Matrix Reloaded, Neo daba otro paso hacia adelante en la búsqueda de la verdad que había empezado con su viaje al mundo real al comienzo de Matrix dejándole a la deriva en una tierra de nadie entre Matrix y el Mundo de las Máquinas.", "Matrix Revolutions", "<iframe width='660' height='315' src='https://www.youtube.com/embed/hMbexEPAOQI' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 8, "https://imagenes.gatotv.com/categorias/peliculas/posters/infinite_2021.jpg", "Acosado por los recuerdos de lugares que nunca ha visitado, un hombre une fuerzas con un grupo de guerreros renacidos para evitar que un loco destruya el ciclo interminable de la vida y la reencarnación.", "Infinite", "<iframe width='660' height='315' src='https://www.youtube.com/embed/UKFjeglbNDg' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 7, "https://m.cinesargentinos.com.ar/poster/8898-el-rescate.jpg?1626438971", "Cuando el amor de su vida es secuestrado por terroristas para pedir un rescate, un héroe de guerra Brad Paxton corre contra el reloj para rescatar a la mujer que ama.", "El Rescate", "<iframe width='660' height='315' src='https://www.youtube.com/embed/BC2rFPNjnp0' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 6, "https://es.web.img3.acsta.net/r_1920_1080/pictures/20/12/28/10/26/5942577.jpg", "Jim es un ex infante de marina que vive una vida solitaria como ranchero a lo largo de la frontera entre Arizona y México. Pero su existencia pacífica pronto se derrumba cuando intenta proteger a un niño que huye de los miembros de un cartel vicioso.", "The marksman", "<iframe width='660' height='315' src='https://www.youtube.com/embed/dpR5rte-96w' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 5, "https://pics.filmaffinity.com/luca-907827591-large.jpg", "Ambientada en una hermosa ciudad costera en la Riviera italiana, la película animada original es una historia sobre la mayoría de edad sobre un niño que experimenta un verano inolvidable lleno de helados, pasta e interminables paseos en scooter.", "Luca", "<iframe width='660' height='315' src='https://www.youtube.com/embed/_-8G-NSeZwo' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 4, "https://pics.filmaffinity.com/sonic_the_hedgehog-730493692-large.jpg", "El mundo necesitaba un héroe, tenía un erizo. Impulsado con una velocidad increíble, Sonic abraza su nuevo hogar en la Tierra, hasta que accidentalmente golpea la red eléctrica, lo que despierta la atención del genio malvado Dr. Robotnik.", "Sonic the hedgehog", "<iframe width='660' height='315' src='https://www.youtube.com/embed/Xb3E8eWZ1mk' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 3, "https://terrigen-cdn-dev.marvel.com/content/prod/1x/snh_online_6072x9000_hero_03_opt.jpg", "La identidad de Spider-Man se revela a todos, ya no es capaz de separar su vida normal de los enormes riesgos que conlleva ser un Súper Héroe. Cuando pide ayuda a Doctor Strange, los riesgos pasan a ser aún más peligrosos.", "Spiderman: No way home", "<iframe width='660' height='315' src='https://www.youtube.com/embed/6QkTCmhOzuA' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 2, "https://m.media-amazon.com/images/I/71niXI3lxlL._AC_SL1183_.jpg", "Después de los eventos devastadores de 'Avengers: Infinity War', el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Los Vengadores deberán reunirse para intentar restaurar el orden en el universo de una vez por todas.", "Avengers EndGame", "<iframe width='660' height='315' src='https://www.youtube.com/embed/znk2OICHbjY' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" },
                    { 10, "https://pics.filmaffinity.com/tom_and_jerry-740894888-large.jpg", "Una rivalidad legendaria resurge cuando Jerry se muda al mejor hotel de la ciudad de Nueva York en vísperas de la boda del siglo, lo que obliga al desesperado planificador de eventos a contratar a Tom para deshacerse de él.", "Tom y jerry", "<iframe width='660' height='315' src='https://www.youtube.com/embed/ZJVb-IR1Jnw' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 2, 15 },
                    { 1, 5 },
                    { 3, 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 3);
        }
    }
}
