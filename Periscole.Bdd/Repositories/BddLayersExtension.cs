using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Periscole.Bdd.Repositories
{
    /// <summary>
    /// Extension pour le référencement du Bdd (DataAccessLayer)
    /// </summary>
    public static class BddLayersExtension
    {
        /// <summary>
        /// Méthode pour enregistrer les services d'accès au context SQL de la BDD.
        /// </summary>
        /// <param name="services">Service collection de l'application</param>
        /// <returns>Service collection mis à jour</returns>
        public static IServiceCollection PeriscoleBddRegisterService(this IServiceCollection services)
        {
            services.AddDbContext<PeriscoleContext>(static (serviceProvider, options) =>
            {
                IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
                string? connectionString = configuration.GetConnectionString("PeriscoleDBConnexion");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La chaîne de connexion 'PeriscoleDBConnexion' est introuvable dans la configuration.");
                }
                options.UseSqlServer(connectionString);
            });

            //services.AddDbContext<PeriscoleContext>(static (serviceProvider, options) => {
            //    IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            //    options.UseSqlServer(configuration.GetConnectionString("PeriscoleDBConnexion")!);
            //});

            return services;
        }
    }
}
