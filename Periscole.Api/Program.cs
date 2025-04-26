
using Microsoft.EntityFrameworkCore; // <-- important si tu utilises un DbContext
using Periscole.Api.Extensions;
using Periscole.Bdd;
using Serilog;



var builder = WebApplication.CreateBuilder(args);


// Ajoute Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Intégration de la chaine de connexion
var connectionString = builder.Configuration.GetConnectionString("PeriscoleDbConnexion");

// Exemple : si tu as un DbContext nommé PeriscoleDbContext
builder.Services.AddDbContext<PeriscoleDbContext>(options =>
    options.UseSqlServer(connectionString));

// Intégration des repositories !
builder.Services.RepositoryRegisterService();

var app = builder.Build();

// Test de la connexion à la base
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
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

