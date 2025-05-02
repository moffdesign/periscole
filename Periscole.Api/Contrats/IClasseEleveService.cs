using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periscole.Api;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd.Contrats
{
    public interface IClasseEleveService
    {
        /// <summary>
        /// Ajouter une affectation d'élève à une classe pour une année scolaire donnée.
        /// </summary>
        Task<Result<bool>> AffectaterEleveDansUneClasseAsync(int anneeScoId, int classeId, int eleveId);

        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="classeId">Identifiant de la classe.</param>
        /// <param name="anneeScoId">Identifiant de l'année scolaire.</param>
        /// <returns>Liste des élèves trouvés de la classe pour l'année scolaire donnée.</returns>
        Task<Result<IList<Eleve>>> RecupererElevesClasseAsync(int classeId, int anneeScoId);


        /// <summary>
        /// Supprimer l'affectation d'un élève à une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <param name="eleveId">élève</param>
        /// <returns>booléan</returns>
        Task<Result<bool>> SupprimerAffectationEleveAsync(int anneeScoId, int classeId, int eleveId);

    }
}
