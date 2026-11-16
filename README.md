
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

## Despliegue

El archivo despliegue.yml utilizará la imagen publicada en Docker Hub sin compilar el código fuente.

Los pasos de ejecución y verificación se completarán después de probar el despliegue.

## Uso de inteligencia artificial

Se utilizó ChatGPT como apoyo para preparar la estructura del proyecto y las configuraciones de Docker.

La explicación de la consulta sobre despliegue.yml y su verificación se añadirá después de realizar las pruebas.
