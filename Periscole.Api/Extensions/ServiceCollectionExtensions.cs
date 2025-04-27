using Microsoft.Extensions.DependencyInjection;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;
using Periscole.Bdd.Repositories;

namespace Periscole.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RepositoryRegisterService(this IServiceCollection services)
        {
            // les services du Repository
             services.AddScoped<IClasseEleveRepository, ClasseEleveRepository>();

             services.AddScoped<IGenericRepository<Matiere>, GenericRepository<Matiere>>();
             services.AddScoped<IGenericRepository<Enseigner>, GenericRepository<Enseigner>>();

            // les services de l'Api
            services.AddScoped<IClasseElevesService, ClasseElevesService>();
            // services.AddScoped<IYourRepository, YourRepositoryImplementation>();

            return services;
        }
    }
}
