using Periscole.Bdd.Domaine;

namespace Periscole.Api.Contrats
{
    public interface IEleveService
    {
        /// <summary>
        /// Ajouter un élève à la base de données.
        /// </summary>
        /// <param name="eleve">élève</param>
        /// <returns></returns>
        Task<Result<Eleve>> AjouterEleveAsync(Eleve eleve);

        /// <summary>
        /// Modifier un élève à la base de données.
        /// </summary>
        /// <param name="eleve">éleve</param>
        /// <returns></returns>
        Task<Result<Eleve>> ModifierEleveAsync(Eleve eleve);

        /// <summary>
        /// Supprimer un élève.
        /// </summary>
        /// <param name="id">ID élève</param>
        /// <returns>bool</returns>
        Task<Result<bool>> SupprimerEleveAsync(int id);

        /// <summary>
        /// Récupérer un élève par son ID.
        /// </summary>
        /// <param name="id">ID élève</param>
        /// <returns>bool</returns>
        Task<Result<Eleve>> GetEleveByIdAsync(int id);

        /// <summary>
        /// Récupérer la liste des élèves.
        /// </summary>
        /// <returns>flux</returns>
        Task<Result<IList<Eleve>>> RecupererListeElevesAsync();

        /// <summary>
        /// Récupérer la liste des élèves pour une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <returns>flux</returns>
        Task<Result<IList<Eleve>>> RecupererElevesAnneeScoAsync(int anneeScoId);

        /// <summary>
        /// Récupérer la liste des élèves pour une classe pour une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <returns>flux</returns>
        Task<Result<IList<Eleve>>> RecupererElevesClasseAsync(int anneeScoId, int classeId);

        /// <summary>
        /// Récupérer la liste des élèves pour un nom et/ou un prénom passés en paramètre
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenon</param>
        /// <returns></returns>
        Task<Result<IList<Eleve>>> GetElevesByNomPrenomAsync(string? nom, string? prenom);
    }
}
