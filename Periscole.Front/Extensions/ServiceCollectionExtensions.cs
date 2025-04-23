using Microsoft.Extensions.DependencyInjection;
using Periscole.Bdd;

namespace Periscole.Front.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RepositoryRegisterService(this IServiceCollection services)
        {
            //services.AddDbContext<PeriscoleContext>(static (serviceProvider, options) =>
            //{
            //    IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            //    string? connectionString = configuration.GetConnectionString("PeriscoleDevConnexion");
            //    if (string.IsNullOrEmpty(connectionString))
            //    {
            //        throw new InvalidOperationException("La chaîne de connexion 'PeriscoleDevConnexion' est introuvable dans la configuration.");
            //    }
            //    options.UseSqlServer(connectionString);
            //});

            //services.AddDbContext<PeriscoleContext>(static (serviceProvider, options) => {
            //    IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            //    options.UseSqlServer(configuration.GetConnectionString("PeriscoleDBConnexion")!);
            //});

            // Register your repositories here, for example:
            // services.AddScoped<IYourRepository, YourRepositoryImplementation>();
            //services.AddTransient<IClientRepository, ClientRepository>();
            return services;
        }
    }
}
