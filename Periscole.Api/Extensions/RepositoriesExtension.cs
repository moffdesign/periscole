using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Periscole.Bdd.Repositories
{
    /// <summary>
    /// Extension pour le référencement du DataAccessLayer
    /// </summary>
    public static class RepositoriesExtension
    {
        /// <summary>
        /// Méthode pour enregistrer les services d'accès aux répository.
        /// </summary>
        /// <param name="services">Service collection de l'application</param>
        /// <returns>Service collection mis à jour</returns>
        public static IServiceCollection RepositoryRegisterService(this IServiceCollection services)
        {
            //services.AddTransient<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
