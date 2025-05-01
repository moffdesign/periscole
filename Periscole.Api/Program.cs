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

// V�rifie si l'extension AddServiceDefaults est d�finie dans un espace de noms ou une biblioth�que sp�cifique
// Si elle est manquante, il faut soit l'impl�menter, soit inclure la biblioth�que correspondante.

var builder = WebApplication.CreateBuilder(args);

// Remplacez ou impl�mentez AddServiceDefaults si elle n'existe pas
// Exemple d'impl�mentation possible si AddServiceDefaults est une m�thode d'extension personnalis�e
//builder.Services.AddServiceDefaults(); // Assurez-vous que cette m�thode est d�finie dans Periscole.Api.Extensions ou ailleurs

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

// Int�gration de la chaine de connexion
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

// Int�gration des repositories !
builder.Services.RepositoryRegisterService();

var app = builder.Build();

// Test de la connexion � la bdd.
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<PeriscoleDbContext>();

    try
    {
        if (!dbContext.Database.CanConnect())
        {
            logger.LogCritical("La connexion � la base de donn�es Periscole a �chou�.");
            throw new Exception("Impossible de se connecter � la base de donn�es via PeriscoleConnexion.");
        }
        else
        {
            logger.LogInformation("Connexion � la base de donn�es Periscole r�ussie.");
        }
    }
    catch (Exception ex)
    {
        logger.LogCritical(ex, "Erreur lors de la tentative de connexion � la base de donn�es Periscole.");
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
