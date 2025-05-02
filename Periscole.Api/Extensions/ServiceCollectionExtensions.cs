using Microsoft.Extensions.DependencyInjection;
using Periscole.Api.Interfaces;
using Periscole.Api.Services;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;
using Periscole.Bdd.Repositories;

namespace Periscole.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RepositoryRegisterService(this IServiceCollection services)
        {
            // les services du Repository génériques
            services.AddScoped<IGenericRepository<AnneeSco>, GenericRepository<AnneeSco>>();
            services.AddScoped<IGenericRepository<Eleve>, GenericRepository<Eleve>>();
            services.AddScoped<IGenericRepository<Classe>, GenericRepository<Classe>>();
            services.AddScoped<IGenericRepository<Professeur>, GenericRepository<Professeur>>();
            services.AddScoped<IGenericRepository<Matiere>, GenericRepository<Matiere>>();
            services.AddScoped<IGenericRepository<Enseigner>, GenericRepository<Enseigner>>();
            services.AddScoped<IGenericRepository<Cours>, GenericRepository<Cours>>();
            services.AddScoped<IGenericRepository<Sequence>, GenericRepository<Sequence>>();
            services.AddScoped<IGenericRepository<NoteSequence>, GenericRepository<NoteSequence>>();
            services.AddScoped<IGenericRepository<Bulletin>, GenericRepository<Bulletin>>();
            services.AddScoped<IGenericRepository<LigneBulletin>, GenericRepository<LigneBulletin>>();
            
            services.AddScoped<IGenericRepository<Controle>, GenericRepository<Controle>>();
            services.AddScoped<IGenericRepository<NoteEleve>, GenericRepository<NoteEleve>>();
            services.AddScoped<IGenericRepository<NoteClasse>, GenericRepository<NoteClasse>>();
            services.AddScoped<IGenericRepository<GroupeMatiere>, GenericRepository<GroupeMatiere>>();
            services.AddScoped<IGenericRepository<ClasseEleve>, GenericRepository<ClasseEleve>>();

            services.AddScoped<IGenericRepository<Parametre>, GenericRepository<Parametre>>();

            // les services du Repository spécifiques
            services.AddScoped<IClasseEleveRepository, ClasseEleveRepository>();
            services.AddScoped<IMatiereRepository, MatiereRepository>();

            // les services de l'Api
            services.AddScoped<IAnneeScoService, AnneeScoService>();
            services.AddScoped<IMatiereService, MatiereService>();
            services.AddScoped<IClasseService, ClasseService>();
            services.AddScoped<IProfesseurService, ProfesseurService>();
            services.AddScoped<IEleveService, EleveService>();
            services.AddScoped<ISequenceService, SequenceService>();
            //services.AddScoped<IBulletinService, BulletinService>();
            //services.AddScoped<IEnseignerService, EnseignerService>();
            services.AddScoped<IClasseEleveService, ClasseEleveService>();
            

            return services;
        }
    }
}
