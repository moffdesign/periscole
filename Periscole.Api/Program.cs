using System;
using Microsoft.EntityFrameworkCore; // <-- important si tu utilises un DbContext
using Periscole.Api.Extensions;
using Periscole.Bdd;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen; // Ajout de l'espace de noms requis pour AddSwaggerGen

// Vérifie si l'extension AddServiceDefaults est définie dans un espace de noms ou une bibliothèque spécifique
// Si elle est manquante, il faut soit l'implémenter, soit inclure la bibliothèque correspondante.

var builder = WebApplication.CreateBuilder(args);

// Remplacez ou implémentez AddServiceDefaults si elle n'existe pas
// Exemple d'implémentation possible si AddServiceDefaults est une méthode d'extension personnalisée
//builder.Services.AddServiceDefaults(); // Assurez-vous que cette méthode est définie dans Periscole.Api.Extensions ou ailleurs

// Ajoute Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Swagger
//builder.Services.AddSwaggerGen(); // Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Periscole API",
        Version = "v1",
        Description = "API de gestion Periscole - Documentation Swagger",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "MOFF Design",
            Email = "guillaumenoah@gmail.com"
        }
    });
});

// Intégration de la chaine de connexion
var connectionString = builder.Configuration.GetConnectionString("PeriscoleConnexion");

builder.Services.AddDbContext<PeriscoleDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddSwagger();
//builder.Services.AddAuth(builder.Configuration);
//builder.Services.AddInfrastructure("CleanArchitecture.Infrastructure", dbConnectionString!);
//builder.Services.AddQueryHandlers();
//builder.Services.AddServices();
//builder.Services.AddSortProviders();
//builder.Services.AddCommandHandlers();
//builder.Services.AddNotificationHandlers();
//builder.Services.AddApiUser();

// Intégration des repositories !
builder.Services.RepositoryRegisterService();

var app = builder.Build();

// Test de la connexion à la bdd.
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<PeriscoleDbContext>();

    try
    {
        if (!dbContext.Database.CanConnect())
        {
            logger.LogCritical("La connexion à la base de données Periscole a échoué.");
            throw new Exception("Impossible de se connecter à la base de données via PeriscoleConnexion.");
        }
        else
        {
            logger.LogInformation("Connexion à la base de données Periscole réussie.");
        }
    }
    catch (Exception ex)
    {
        logger.LogCritical(ex, "Erreur lors de la tentative de connexion à la base de données Periscole.");
        throw; // On relance pour stopper l'appli
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Periscole API v1");
        c.RoutePrefix = string.Empty; // <- Swagger sera directement sur "/"
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
