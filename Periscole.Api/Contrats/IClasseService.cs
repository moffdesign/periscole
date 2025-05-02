using Periscole.Bdd.Domaine;

namespace Periscole.Api.Contrats
{
    public interface IClasseService
    {
        /// <summary>
        /// Ajouter une classe.
        /// </summary>
        /// <param name="classe"></param>
        /// <returns></returns>
        Task<Result<bool>> AjouterClasse(Classe classe);

        /// <summary>
        /// Modifier une classe.
        /// </summary>
        /// <param name="classe">classe</param>
        /// <returns>boolean</returns>
        Task<Result<bool>> ModifierClasse(Classe classe);

        /// <summary>
        /// Supprimer une classe.
        /// </summary>
        /// <param name="classeId">Id classe</param>
        /// <returns>boolean</returns>
        Task<Result<bool>> SupprimerClasse(int classeId);

        /// <summary>
        /// Récupérer une classe.
        /// </summary>
        /// <param name="classeId">Id classe</param>
        /// <returns>classe</returns>
        Task<Result<Classe>> RecupererClasse(int classeId);

        /// <summary>
        /// Récupérer la liste des classes ouvertes pour l'année scolaire spécifiée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <returns>flux</returns>
        Task<Result<IList<Classe>>> RecupererClasses(int? anneeScoId);

        /// <summary>
        /// Récupérer la liste des classes tenues par un professeur pour une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="professeurId">professeur</param>
        /// <returns>flux</returns>
        Task<Result<IList<Classe>>> RecupererClassesParProfesseur(int anneeScoId, int professeurId);

        /// <summary>
        /// Récupérer la liste des matières dispensées dans une classe pour une année scolaire et un niveau.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <returns>flux</returns>
        Task<Result<IList<Classe>>> RecupererMatieresClasse(int anneeScoId, int classeId);
    }
}
