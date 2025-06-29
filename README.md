## 🎬 TPI Cine - Proyecto Software [Fullstack]

![Vista principal](Assets/Portada_frontend.png)

Este proyecto es una **aplicación fullstack para una página de cine**, desarrollada con **.NET + Entity Framework Core** en el backend y JavaScript, HTML y CSS en el frontend. Fue creado como trabajo individual para la materia *Proyecto Software* de la carrera de Ingeniería en Informática.

El objetivo es **aplicar conocimientos adquiridos** durante la carrera y sumar experiencia en prácticas profesionales tanto del lado del backend como del frontend.

---

### 📁 Estructura del repositorio

TPICine/
├── backend/ # Proyecto backend (.NET, C#)
├── frontend/ # Proyecto frontend (HTML, CSS, JS)
├── assets/ # Imágenes y recursos utilizados en el README
└── README.md # Este archivo

---

## 🧩 Backend

![Vista principal](../Assets/Portada_backend.png)

### 🔧 Instalación y configuración

1. Cloná este repositorio:

   ```bash
   git clone https://github.com/tu-usuario/TPICine.git
   ```

2. Abrí la carpeta backend con Visual Studio y permití que instale automáticamente las dependencias de NuGet.

3. Asegurate de tener instalados:

- SQL Server Express

- SQL Server Management Studio (SSMS)

Configurá el archivo appsettings.Development.json con tu ConnectionString.

📌 Ejemplo recomendado:

"ConnectionString": "Server=localhost\\SQLEXPRESS;Database=TPICineDB2;Trusted_Connection=True;Encrypt=False;"

5. Generá la base de datos desde el código (Code First) usando la consola del Administrador de Paquetes NuGet:

```bash
    Add-Migration Initial
    Update-Database
```

Esto cargará automáticamente películas y salas en la base de datos.

🚀 Funcionalidades principales del backend
Estas funcionalidades se pueden probar utilizando Swagger:

- 🔍 Ver la información de una película.

- 📅 Listar funciones por día y/o título de película.

- ➕ Registrar una nueva función.

- 🗑️ Eliminar una función.

- 🎟️ Obtener un ticket para una función.

- 🎬 Ver todas las funciones disponibles para una película.

- ✏️ Actualizar la información de una película.

- 📊 Consultar la cantidad de tickets disponibles para una función.

---

💡 Ejemplo de uso
Para agregar funciones, hacé una solicitud POST al endpoint:

/api/función

Formato de la solicitud (JSON):

{
  "peliculaId": 1,
  "salaId": 2,
  "fecha": "2025/10/13",
  "horario": "16:00"
}

📌 Formato de fecha: AAAA/MM/DD — Formato de horario: HH:MM

---

🛠️ Tecnologías y herramientas utilizadas en el backend

- 💻 C#

- 🛠️ .NET / Entity Framework Core

- 🧪 Swagger

- 🗃️ SQL Server Express

---

🎨 Frontend

![Vista principal](../Assets/Portada_frontend.png)

Este módulo, ubicado en la carpeta `/frontend`, permite al usuario **interactuar con la plataforma de cine** consumiendo los endpoints expuestos por el backend. Brinda una experiencia sencilla para visualizar películas, funciones y comprar tickets.

---

### 🔧 Instalación y ejecución

1. Cloná el repositorio si aún no lo hiciste:

   ```bash
   git clone https://github.com/tu-usuario/TPICine.git
   ```

2. (Opcional) Instalá la extensión Live Server en Visual Studio Code para facilitar la vista previa del sitio.

3. Levantá el proyecto abriendo index.html con Live Server o directamente en tu navegador.

---

🚀 Funcionalidades principales

- 🎬 Ver todas las películas disponibles para el día actual.

- 🔍 Acceder al detalle de cada película con toda su información.

- 📅 Buscar funciones por fecha y/o título de película.

- 🎟️ Seleccionar una función y simular la compra de tickets.

---

### 💡 Consejos

- Las funciones deben ser previamente cargadas desde el backend.
Consultá el apartado de Consejos en el README del backend para más detalles sobre cómo hacerlo usando Swagger.

---

🛠️ Tecnologías y herramientas utilizadas

- 🧩 JavaScript

- 🎨 HTML5

- 🖌️ CSS3

---

❗ Importante
Este repositorio contiene tanto el backend como el frontend del proyecto.
Para su correcto funcionamiento, asegurate de configurar ambos entornos de forma independiente y seguir las instrucciones respectivas.

---

¡Gracias por visitar este repositorio! 😊
¿Querés contribuir o dejar comentarios? ¡Todo feedback es bienvenido!
