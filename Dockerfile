FROM mcr.microsoft.com/dotnet/sdk:10.0 AS base
WORKDIR /src

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS restore
WORKDIR /src

COPY Domain/Domain.csproj Domain/
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Lumiere.Backend/Lumiere.Backend.csproj Lumiere.Backend/
COPY Tests/Lumiere.Backend.Tests/Lumiere.Backend.Tests.csproj Tests/Lumiere.Backend.Tests/

COPY Lumiere.Backend.slnx ./

RUN dotnet restore Lumiere.Backend.slnx

FROM restore AS build
WORKDIR /src

COPY Domain/ Domain/
COPY Application/ Application/
COPY Infrastructure/ Infrastructure/
COPY Lumiere.Backend/ Lumiere.Backend/
COPY Tests/ Tests/

RUN dotnet build Lumiere.Backend.slnx -c Release --no-restore

FROM build AS publish
WORKDIR /src

RUN dotnet publish Lumiere.Backend/Lumiere.Backend.csproj \
    -c Release \
    --no-restore \
    --no-build \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

USER root
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

USER $APP_UID

COPY --from=publish --chown=$APP_UID:$APP_UID /app/publish .

EXPOSE 8080

ENV ASPNETCORE_HTTP_PORTS=8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__DefaultConnection=

HEALTHCHECK --interval=30s --timeout=3s --start-period=10s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Lumiere.Backend.dll"]