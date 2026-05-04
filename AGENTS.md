# AGENTS.md — Lumiere Backend

## Quick start

```powershell
dotnet restore
dotnet build
dotnet test
```

Run the API (requires PostgreSQL, see `appsettings.Development.json`):

```powershell
dotnet run --project Lumiere.Backend
```

Scalar docs at `/scalar/v1` (dev only), health check at `/health`.

## Project layout

```
Domain/               # Entities, interfaces, enums — zero deps
Application/          # CQRS handlers, commands, queries, validators, mapping configs
Infrastructure/       # EF Core DbContext, repositories, migrations
Lumiere.Backend/      # ASP.NET API (controllers, middleware, Program.cs)
Tests/                # xUnit + NetArchTest + FluentAssertions
```

**Dependency flow:** Lumiere.Backend → Application → Domain; Lumiere.Backend → Infrastructure → Domain. Application never references Infrastructure.

## Key commands

| Action | Command |
|--------|---------|
| Build | `dotnet build` |
| Full test suite | `dotnet test` |
| Run API | `dotnet run --project Lumiere.Backend` |
| Add migration | `dotnet ef migrations add <Name> --project Infrastructure --startup-project Lumiere.Backend` |
| Apply migration | `dotnet ef database update --project Infrastructure --startup-project Lumiere.Backend` |

## Architecture & conventions

- **CQRS via MediatR 14**: Each operation is a `record` implementing `IRequest<TResponse>` in `Application/Features/{Entity}/{Action}/`.
- **Naming**: `{Action}{Entity}Command` / `{Action}{Entity}Handler` / `{Action}{Entity}Validator`. Queries use `Get{Entity}ByIdQuery` and `GetList{Entity}Query`. Response DTOs use `{Entity}Response` / `{Entity}ListResponse`.
- **Controllers** inject `IMediator` directly — no service layer. Each maps CRUD to a command/query.
- **Handlers** inject the specific repository + `IUnitOfWork` and call `unitOfWork.SaveChangesAsync()` themselves.
- **Mapster 10** for entity→DTO mapping. Config classes in `Application/Mappings/` implement `IRegister`.
- **FluentValidation 12** auto-registered via `AddValidatorsFromAssembly`. Pipeline behavior runs before each handler.
- **Soft delete**: `State` enum (`Active=1`, `Inactive=0`, `Deleted=-1`, `Archived=2`). `AppDbContext.SaveChangesAsync` intercepts `EntityState.Deleted` → sets `State = Deleted` and cascades to navigation properties. Repositories filter `w.State == State.Active`.
- **Audit fields**: `Created`/`CreatedBy`/`Modified`/`ModifiedBy` auto-filled with `"UserAdmin"` (hardcoded placeholder).
- **Snake-case naming**: EF Core configured with `UseSnakeCaseNamingConvention()`. All DB columns are snake_case.

## Testing

- **Architecture tests** (`Tests/.../Architecture/`): Validate layer dependencies, naming conventions, and that response DTOs don't reference domain entities. Uses NetArchTest.
- **Mapping tests** (`Tests/.../Integration/Mapping/`): Verify Mapster configs work. Do NOT require a database — test via `new TypeAdapterConfig` + `Scan`.
- No database integration tests exist yet.