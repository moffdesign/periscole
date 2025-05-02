using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd.Contrats
{
    public interface IClasseEleveRepository
    {
        /// <summary>
        /// Affecter un élève à une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <param name="eleveId">élève</param>
        /// <returns>Un booléen indiquant si l'affectation a réussi.</returns>
        Task<bool> AffecterEleveDansClasseAsync(int anneeScoId, int classeId, int eleveId);

        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <returns>flux élèves</returns>
        Task<List<Eleve>> RecupererElevesParClasseAsync(int anneeScoId, int classeId);

        /// <summary>
        /// Supprimer une affectation d'élève à une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <param name="eleveId">élève</param>
        /// <returns></returns>
        Task<bool> SupprimerAffectationEleveAsync(int anneeScoId, int classeId, int eleveId);
    }
}
