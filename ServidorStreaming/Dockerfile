# Etapa 1: Compilar la API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ServidorStreaming.csproj ./
RUN dotnet restore

COPY . .

RUN dotnet build -c Release -o /app/build --no-restore

# Etapa 2: Ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/build .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "ServidorStreaming.dll"]
