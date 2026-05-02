# Lumiere Backend

Cinema, room, screening and booking management system. Built with .NET 10 following Clean Architecture and CQRS.

## Requirements

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- PostgreSQL 15+
- Recommended IDE: Rider / VS Code / Visual Studio 2022

## Technologies

| Layer | Technology |
|-------|------------|
| Backend | ASP.NET Core 10 |
| ORM | Entity Framework Core 10 |
| Database | PostgreSQL |
| CQRS | MediatR 14 |
| Validation | FluentValidation 12 |
| Mapping | Mapster 10 |
| API Docs | Scalar |
| Testing | xUnit + NetArchTest + FluentAssertions |

## Structure

```
src/
├── Domain/               # Entities, interfaces, enums (zero dependencies)
├── Application/          # Use cases (Commands, Queries, Handlers)
├── Infrastructure/       # EF Core persistence, repositories, DbContext
└── Lumiere.Backend/      # REST API (Controllers, Middleware, Program.cs)

tests/
└── Lumiere.Backend.Tests/
    ├── Architecture/     # Architectural governance rules (NetArchTest)
    └── Integration/      # Mapping and serialization tests
```

### Layer dependencies

```
Lumiere.Backend (Web)
├── Application (Use Cases)
│   └── Domain (Entities, Interfaces)
└── Infrastructure (Persistence)
    └── Domain
```

## Domain entities

- **Movie** (title, genre, duration, classification)
- **Cinema** (address, associated rooms)
- **Room** (number, capacity, seats)
- **Seat** (row, column)
- **Screening** (dates, movie, room)
- **Booking** (date, total, payment method, user)
- **User**

## Useful commands

### Build
```bash
dotnet build
```

### Run tests
```bash
dotnet test
```

### Run API
```bash
cd Lumiere.Backend
dotnet run
```

API Endpoints & Profiles

The API exposure depends on the active launch profile:

    Kestrel (HTTPS): https://localhost:7080

    Kestrel (HTTP): http://localhost:5080

    IIS Express: http://localhost:44364.

Regardless of the profile, the interactive documentation (Scalar) is available at /scalar/v1.

## Code conventions

- Handlers: `{Operation}{Entity}Handler` (e.g. `CreateMovieHandler`)
- Commands: `{Operation}{Entity}Command` (implements `IRequest<Guid>`)
- Queries: `Get{Entity}ByIdQuery` / `GetList{Entity}Query`
- Validators: `{Operation}{Entity}Validator`
- Response DTOs: `{Entity}Response` / `{Entity}ListResponse`

## Architectural principles

- **CQRS**: Commands (write) and Queries (read) are separated
- **Clean Architecture**: Dependencies point inward, Domain at the center
- **Specific repositories**: Each handler injects only the repository it needs plus a thin `IUnitOfWork` scoped to `SaveChangesAsync`
- **Automated governance**: Architecture tests with NetArchTest validate dependencies, naming, and absence of entity-to-DTO leaks
