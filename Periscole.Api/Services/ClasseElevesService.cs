using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;

namespace Periscole.Bdd.Repositories
{
    public class ClasseElevesService : IClasseElevesService
    {
        private IClasseEleveRepository _classeEleveRepository;

        public ClasseElevesService(IClasseEleveRepository repoClasse)
        {
            _classeEleveRepository = repoClasse;
        }

        public async Task<Result<bool>> AffectationEleveDansUneClasseAsync(int anneeScoId, int classeId, int eleveId)
        {
            var result = await _classeEleveRepository.AffecterEleveDansClasseAsync(anneeScoId, classeId, eleveId);

            if (result)
            {
                return Result<bool>.Ok(true);
            }
            else
            {
                return Result<bool>.Fail("ECHEC","L'affectation a échoué.", 400);
            }
        }

        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="classeId">ID Classe</param>
        /// <param name="anneeScoId">ID AnnéeSco</param>
        /// <returns>list élèves</returns>
        public async Task<IList<Eleve>> RecupererElevesClasseAsync(int anneeScoId, int classeId)
        {
            var result = await _classeEleveRepository.RecupererElevesParClasseAsync(anneeScoId, classeId);

            // Vérifier si la liste d'élèves est vide ou nulle
            if (result != null && result.Count > 0)
            {
                return result;
            }
            else
            {
                // Gérer le cas où aucun élève n'est trouvé
                // Vous pouvez lancer une exception ou retourner une liste vide
                //throw new Exception("Aucun élève trouvé pour cette classe et cette année scolaire.");
                return new List<Eleve>();
            }
        }

    }
}
