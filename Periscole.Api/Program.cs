
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

// Int�gration de la chaine de connexion
var connectionString = builder.Configuration.GetConnectionString("PeriscoleDbConnexion");

// Exemple : si tu as un DbContext nomm� PeriscoleDbContext
builder.Services.AddDbContext<PeriscoleDbContext>(options =>
    options.UseSqlServer(connectionString));

// Int�gration des repositories !
builder.Services.RepositoryRegisterService();

var app = builder.Build();

// Test de la connexion � la base
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
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

