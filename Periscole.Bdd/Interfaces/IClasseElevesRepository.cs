using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd.Interfaces
{
    public interface IClasseElevesRepository
    {
        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="classeId">Identifiant de la classe.</param>
        /// <param name="anneeScoId">Identifiant de l'année scolaire.</param>
        /// <returns>Liste des élèves de la classe pour l'année scolaire donnée.</returns>
        Task<IList<Eleve>> RecupererElevesClasseAsync(int classeId, int anneeScoId);

        /// <summary>
        /// Ajouter une affectation d'élève à une classe pour une année scolaire donnée.
        /// </summary>
        Task AffectationEleveClasseAsync(int anneeScoId, int classeId, int eleveId);

        //void AffectationEleveClasse(ClasseEleve classeEleve);

    }
}
