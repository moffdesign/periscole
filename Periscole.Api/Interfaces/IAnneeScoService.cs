using Periscole.Bdd.Domaine;

namespace Periscole.Api.Interfaces
{
    public interface IAnneeScoService
    {
        /// <summary>
        /// Ajouter une année scolaire.
        /// </summary>
        /// <param name="anneeSco"></param>
        /// <returns></returns>
        Task<Result<bool>> AjouterAnneeSco(AnneeSco anneeSco);

        /// <summary>
        /// Modifier une année scolaire.
        /// </summary>
        /// <param name="anneeSco">année scolaire</param>
        /// <returns>boolean</returns>
        Task<Result<bool>> ModifierAnneeSco(AnneeSco anneeSco);

        /// <summary>
        /// Supprimer une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">Id année scolaire</param>
        /// <returns>boolean</returns>
        Task<Result<bool>> SupprimerAnneeSco(int anneeScoId);

        /// <summary>
        /// Récupérer une année scolaire.
        /// </summary>
        /// <param name="anneeScoId">Id année scolaire</param>
        /// <returns>année scolaire</returns>
        Task<Result<AnneeSco>> RecupererAnneeSco(int anneeScoId);

        /// <summary>
        /// Récupérer la liste des années scolaires enregistrées
        /// </summary>
        /// <returns>flux</returns>
        Task<Result<IList<AnneeSco>>> ListeAnneesScolaires();
    }
}
