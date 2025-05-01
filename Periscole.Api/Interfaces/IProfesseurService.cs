using Periscole.Bdd.Domaine;

namespace Periscole.Api.Interfaces
{
    public interface IProfesseurService
    {
        /// <summary>
        /// Ajouter un professeur à la base de données.
        /// </summary>
        /// <param name="professeur">professeur</param>
        /// <returns>bool</returns>
        Task<Result<Professeur>> AjouterProfesseurAsync(Professeur professeur);

        /// <summary>
        /// Modifier un professeur.
        /// </summary>
        /// <param name="professeur">professeur</param>
        /// <returns>bool</returns>
        Task<Result<Professeur>> ModifierProfesseurAsync(Professeur professeur);

        /// <summary>
        /// Supprimer un professeur.
        /// </summary>
        /// <param name="professeurId">ID prof</param>
        /// <returns>bool</returns>
        Task<Result<bool>> SupprimerProfesseurAsync(int professeurId);

        /// <summary>
        /// Récupérer un professeur.
        /// </summary>
        /// <param name="professeurId">ID prof</param>
        /// <returns>professeur</returns>
        Task<Result<Professeur>> RecupererProfesseurAsync(int professeurId);

        /// <summary>
        /// Récupérer la liste des professeurs.
        /// si l'année est spécifiée alors on filtre par année sinon on récupère tous les professeurs.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <returns>flux</returns>
        Task<Result<IList<Professeur>>> RecupererProfesseursAsync(int? anneeScoId);

        /// <summary>
        /// Récupérer la liste des professeurs enseignant dans une classe pour une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <returns>flux profs</returns>
        Task<Result<IList<Professeur>>> RecupererProfesseursClasseAsync(int anneeScoId, int classeId);

        /// <summary>
        /// Affecter des professeurs à une classe pour une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <param name="professeurs">professeurs</param>
        /// <returns>booléan</returns>
        Task<Result<bool>> AffecterProfesseursClasseAsync(int anneeScoId, int classeId, IList<Professeur> professeurs);

        //Task<Result<bool>> ModifierProfesseurClasse(int anneeScoId, int classeId, int professeurId, Professeur professeur);
        //Task<Result<bool>> InitialiserProfesseursClasse(int anneeScoId, int classeId);
    }
}
