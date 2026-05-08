using Lumiere.Backend.Middlewares;
using Lumiere.Infrastructure;
using Application;
using Scalar.AspNetCore;
using Lumiere.Backend.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
                .AddApplicationServices()
                .AddInfrastructure(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)

                .AddProblemDetails()
                .AddExceptionHandler<GlobalExceptionHandler>()

                .AddOpenApi("v1", options => { options.AddDocumentTransformer<BearerSecuritySchemeTransformer>(); })
                .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Lumiere API")
            .WithTheme(ScalarTheme.Moon)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .AddPreferredSecuritySchemes("Bearer")
            .AddHttpAuthentication("Bearer", bearer =>
            {
                bearer.Token = "xxxxxxxxx.yyyyyyyyy.aaaaaaaaa";
            }).EnablePersistentAuthentication();
    });
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();

public partial class Program { }
