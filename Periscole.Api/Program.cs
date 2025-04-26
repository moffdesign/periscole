
using Microsoft.EntityFrameworkCore; // <-- important si tu utilises un DbContext
using Periscole.Api.Extensions;
using Periscole.Bdd;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Intégration de la chaine de connexion
var connectionString = builder.Configuration.GetConnectionString("PeriscoleDbConnexion");

// Exemple : si tu as un DbContext nommé PeriscoleDbContext
builder.Services.AddDbContext<PeriscoleContext>(options =>
    options.UseSqlServer(connectionString));

// Intégration des repositories !
builder.Services.RepositoryRegisterService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

