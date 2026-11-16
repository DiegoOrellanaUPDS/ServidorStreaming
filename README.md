
# ServidorStreaming - API de Categorías

## Descripción del proyecto

Proyecto académico desarrollado para la materia Tecnología Web I.

Consiste en una API REST para gestionar categorías de contenido de una plataforma de streaming.

## Tecnologías utilizadas

- .NET 10 Web API
- Entity Framework Core
- PostgreSQL 17
- Docker y Docker Compose
- Scalar para probar los endpoints
- Git y GitHub

## Integrante y tabla asignada

| Integrante | Tabla | Controlador |
|---|---|---|
| Abraham Valeriano | Categorias | CategoriasController |


## Estructura del proyecto

- contructor.yml: construcción de los contenedores.
- despliegue.yml: despliegue desde Docker Hub.
- .env.example: variables de entorno de ejemplo.
- ServidorStreaming/Dockerfile: imagen del backend.
- ServidorStreaming/Models/: modelo Categoria.
- ServidorStreaming/Controllers/: controlador CRUD.
- ServidorStreaming/Data/: contexto de PostgreSQL.
- ServidorStreaming/Migrations/: migraciones de EF Core.

## Endpoints

| Método | Ruta | Descripción |
|---|---|---|
| GET | /api/Categorias | Listar categorías |
| GET | /api/Categorias/{id} | Buscar por ID |
| POST | /api/Categorias | Crear categoría |
| PUT | /api/Categorias/{id} | Actualizar categoría |
| DELETE | /api/Categorias/{id} | Eliminar categoría |

## Ejecución con Docker Compose

Requisitos: Docker y Docker Compose.

1. Clonar el repositorio.
2. Entrar en la carpeta principal.
3. Crear el archivo .env a partir de .env.example.
4. Configurar una contraseña propia para PostgreSQL.
5. Ejecutar:

    docker compose --env-file .env -f contructor.yml up --build -d

6. Verificar los contenedores:

    docker compose --env-file .env -f contructor.yml ps

## Migraciones

En una base de datos nueva deben aplicarse las migraciones.

Con .NET 10 SDK y dotnet-ef instalados, desde la carpeta de la API, cargar las variables del archivo .env y ejecutar:

    dotnet ef database update

La cadena de conexión para ejecutar migraciones desde Ubuntu debe utilizar localhost y el puerto DB_PORT.

## Pruebas

Scalar está disponible en el entorno de desarrollo:

http://localhost:5090/scalar/v1

Se comprobaron los cinco métodos CRUD y la persistencia de PostgreSQL después de recrear los contenedores.

## Docker Hub

Imagen publicada:

abrahdev/servidorstreaming-api:1.0

Repositorio:

https://hub.docker.com/r/abrahdev/servidorstreaming-api


## Despliegue desde Docker Hub

La aplicación puede ejecutarse sin compilar el código fuente,
utilizando la imagen publicada en Docker Hub.

Imagen: abrahdev/servidorstreaming-api:1.1

### Pasos de despliegue

1. Configurar el archivo .env a partir de .env.example.
2. Descargar la imagen publicada:

   docker compose --env-file .env -f despliegue.yml pull backend

3. Iniciar los servicios:

   docker compose --env-file .env -f despliegue.yml up -d

4. Comprobar los contenedores:

   docker compose --env-file .env -f despliegue.yml ps

5. Probar el endpoint:

   curl -i http://localhost:5090/api/Categorias

El entorno de desarrollo permite acceder a Scalar en:

http://localhost:5090/scalar/v1

## Uso de inteligencia artificial

Se utilizó ChatGPT como herramienta de apoyo para
preparar el archivo despliegue.yml.

### Consulta realizada

Se solicitó preparar un archivo Docker Compose que
ejecute una API .NET 10 utilizando la imagen
abrahdev/servidorstreaming-api:1.1 de Docker Hub,
junto con PostgreSQL 17, una red compartida,
variables de entorno y un volumen para persistencia.

La configuración debía utilizar image en lugar de
build para evitar compilar el código fuente.

### Verificación de la propuesta

1. Se detuvieron los contenedores anteriores.
2. Se descargó la imagen 1.1 desde Docker Hub.
3. Se levantaron ambos servicios con despliegue.yml.
4. Se comprobó que PostgreSQL estuviera saludable.
5. Se ejecutó una petición GET mediante curl.
6. Se obtuvo HTTP/1.1 200 OK y la categoría
   Documentales almacenada en PostgreSQL.

Resultado: el despliegue funcionó correctamente
sin necesidad de compilar el proyecto.
