using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Periscole.Api;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;

namespace Periscole.Bdd.Repositories
{
    public class ClasseEleveService : IClasseEleveService
    {
        private IClasseEleveRepository _classeEleveRepository;
        //private readonly SupprimerAffectationRequestValidator _validator;
        private readonly ILogger<ClasseEleveService> _logger;

        public ClasseEleveService(IClasseEleveRepository repoClasse, ILogger<ClasseEleveService> logger)
        {
            _classeEleveRepository = repoClasse;
            _logger = logger;
        }

        public async Task<Result<bool>> AffectaterEleveDansUneClasseAsync(int anneeScoId, int classeId, int eleveId)
        {
            var result = await _classeEleveRepository.AffecterEleveDansClasseAsync(anneeScoId, classeId, eleveId);

            if (result)
            {
                return Result<bool>.Ok(true);
            }
            else
            {
                return Result<bool>.Fail("ECHEC", "L'élève est déjà affecté à cette classe et cette année scolaire.", 400);
            }
        }

        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="classeId">ID Classe</param>
        /// <param name="anneeScoId">ID AnnéeSco</param>
        /// <returns>list élèves</returns>
        public async Task<Result<IList<Eleve>>> RecupererElevesClasseAsync(int anneeScoId, int classeId)
        {
            var result = await _classeEleveRepository.RecupererElevesParClasseAsync(anneeScoId, classeId);

            // Vérifier si la liste d'élèves est vide ou nulle
            if (result != null && result.Count > 0)
            {
                return Result<IList<Eleve>>.Ok(result, 200);
            }
            else
            {
                // Gérer le cas où aucun élève n'est trouvé, lancer une exception ou retourner une liste vide
                return Result<IList<Eleve>>.Fail("AUCUN_ELEVE", "Aucun élève trouvé pour cette classe et cette année scolaire.", 404);
            }
        }

        public async Task<Result<bool>> SupprimerAffectationEleveAsync(int anneeScoId, int classeId, int eleveId)
        {
            var affectation = await _classeEleveRepository.SupprimerAffectationEleveAsync(anneeScoId, classeId, eleveId);

            if (affectation)
            {
                _logger.LogInformation("Affectation supprimée pour élève {EleveId}", eleveId);
                return Result<bool>.Ok(true);
            }
            else
            {
                _logger.LogWarning("Affectation non trouvée pour élève {EleveId}", eleveId);
                return Result<bool>.Fail("AFFECTATION_NOT_FOUND", "Aucune affectation trouvée pour cet élève.", 404);
            }
        }
    }
}
