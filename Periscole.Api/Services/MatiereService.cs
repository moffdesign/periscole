using Microsoft.EntityFrameworkCore;
using Periscole.Api.Interfaces;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;

namespace Periscole.Api.Services
{
    public class MatiereService : IMatiereService
    {
        private readonly IGenericRepository<Matiere> _matiereRepository;
        private readonly IGenericRepository<Enseigner> _enseignerRepository;
        private readonly ILogger<MatiereService> _logger;
        public MatiereService(IGenericRepository<Matiere> matiereRepository, IGenericRepository<Enseigner> enseignerRepository, ILogger<MatiereService> logger)
        {
            _matiereRepository = matiereRepository;
            _enseignerRepository = enseignerRepository;
            _logger = logger;
        }

        public async Task<Result<bool>> AjouterUneMatiere(Matiere matiere)
        {
            try
            {
                await _matiereRepository.AddAsync(matiere);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de l'ajout de la matière {matiere.Libelle}");
                Result<bool>.Fail("ECHEC", "Erreur lors de l'ajout de la matière.", 500);
            }
            return Result<bool>.Ok(true);
        }
        
        public async Task<Result<bool>> ModifierUneMatiere(Matiere matiere)
        {
            try
            {
                await _matiereRepository.UpdateAsync(matiere);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la modification de la matière {matiere.Libelle}");
                return Result<bool>.Fail("ECHEC", "Erreur lors de la modification de la matière.", 500);
            }
            return Result<bool>.Ok(true);

        }

        public async Task<Result<Matiere>> RecupererUneMatiere(int matiereId)
        {
            try
            {
                var matiere = await _matiereRepository.GetByIdAsync(matiereId);
                if (matiere == null)
                {
                    return Result<Matiere>.Fail("NOT_FOUND", "Matière non trouvée.", 404);
                }
                return Result<Matiere>.Ok(matiere, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération de la matière avec ID {matiereId}");
                return Result<Matiere>.Fail("ECHEC", "Erreur lors de la récupération de la matière.", 500);
            }

        }

        public async Task<Result<bool>> SupprimerUneMatiere(int matiereId)
        {
            try
            {
                await _matiereRepository.DeleteByIdAsync(matiereId);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la suppression de la matière avec ID {matiereId}");
                return Result<bool>.Fail("ECHEC", "Erreur lors de la suppression de la matière.", 500);
            }
            return Result<bool>.Ok(true);
        }

        /// <summary>
        /// Récupérer la liste de toutes les matières.
        /// </summary>
        /// <returns>flux matières</returns>
        public async Task<Result<IList<Matiere>>> RecupererListeMatieres()
        {
            try
            {
                var matieres = await _matiereRepository.GetAllAsync();
                if (matieres == null || !matieres.Any())
                {
                    return Result<IList<Matiere>>.Fail("NOT_FOUND", "Aucune matière trouvée.", 404);
                }
                return Result<IList<Matiere>>.Ok(matieres.ToList(), 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération de la liste des matières");
                return Result<IList<Matiere>>.Fail("ECHEC", "Erreur lors de la récupération de la liste des matières.", 500);
            }

        }

        /// <summary>
        /// Récupérer les matières planifiées pour tout l'établissement pour l'année scolaire.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <returns>flux matières</returns>
        public async Task<Result<IList<Matiere>>> RecupererMatieresParAnneeSco(int anneeScoId)
        {
            try
            {
                var matieres = await _enseignerRepository
                    .Query()
                    .Where(e => e.AnneeScoId == anneeScoId)
                    .Join(
                        _matiereRepository.Query(),
                        enseigner => enseigner.MatiereId,
                        matiere => matiere.Id,
                        (enseigner, matiere) => matiere
                    )
                    .ToListAsync();

                if (matieres == null || !matieres.Any())
                {
                    return Result<IList<Matiere>>.Fail("NOT_FOUND", "Aucune matière trouvée pour l'année scolaire spécifiée.", 404);
                }

                return Result<IList<Matiere>>.Ok(matieres, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération des matières pour l'année scolaire avec ID {anneeScoId}");
                return Result<IList<Matiere>>.Fail("ECHEC", "Erreur lors de la récupération des matières.", 500);
            }
        }

        /// <summary>
        /// Récupérer les matières pour un professeur donné pour une année scolaire donnée.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="professeurId">professeur</param>
        /// <returns>flux matières</returns>
        public async Task<Result<IList<Matiere>>> RecupererMatieresParProfesseur(int anneeScoId, int professeurId)
        {
            try
            {
                var matieres = await _enseignerRepository
                    .Query()
                    .Where(e => e.AnneeScoId == anneeScoId && e.ProfesseurId == professeurId)
                    .Join(
                        _matiereRepository.Query(),
                        enseigner => enseigner.MatiereId,
                        matiere => matiere.Id,
                        (enseigner, matiere) => matiere
                    )
                    .ToListAsync();

                if (matieres == null || !matieres.Any())
                {
                    return Result<IList<Matiere>>.Fail("NOT_FOUND", "Aucune matière trouvée pour le professeur spécifiée.", 404);
                }

                return Result<IList<Matiere>>.Ok(matieres, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération des matières pour le professeur avec ID {professeurId}");
                return Result<IList<Matiere>>.Fail("ECHEC", "Erreur lors de la récupération des matières.", 500);
            }
        }

        /// <summary>
        /// Récupérer les matières pour une classe et une année scolaire données.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <returns>flux matières</returns>
        public async Task<Result<IList<Matiere>>> RecupererMatieresParClasseEtAnneeSco(int anneeScoId, int classeId)
        {
            try
            {
                var matieres = await _enseignerRepository
                    .Query()
                    .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId)
                    .Join(
                        _matiereRepository.Query(),
                        enseigner => enseigner.MatiereId,
                        matiere => matiere.Id,
                        (enseigner, matiere) => matiere
                    )
                    .ToListAsync();

                if (matieres == null || !matieres.Any())
                {
                    return Result<IList<Matiere>>.Fail("NOT_FOUND", "Aucune matière trouvée pour l'année et la classe.", 404);
                }

                return Result<IList<Matiere>>.Ok(matieres, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération des matières pour l'année scolaire avec ID {anneeScoId} et la classe {classeId}");
                return Result<IList<Matiere>>.Fail("ECHEC", "Erreur lors de la récupération des matières.", 500);
            }
        }

        /// <summary>
        /// Récupérer les matières pour une classe, un professeur et une année scolaire donnés.
        /// il est tout à fait possible qu'un même professeur enseiegne plus d'une matière dans une même classe.
        /// </summary>
        /// <param name="anneeScoId">année</param>
        /// <param name="classeId">classe</param>
        /// <param name="professeurId">professeur</param>
        /// <returns>flux matières</returns>
        public async Task<Result<IList<Matiere>>> RecupererMatieresParClasseProfesseurAnneeSco(int anneeScoId, int classeId, int professeurId)
        {
            try
            {
                var matieres = await _enseignerRepository
                    .Query()
                    .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId && e.ProfesseurId == professeurId)
                    .Join(
                        _matiereRepository.Query(),
                        enseigner => enseigner.MatiereId,
                        matiere => matiere.Id,
                        (enseigner, matiere) => matiere
                    )
                    .ToListAsync();

                if (matieres == null || !matieres.Any())
                {
                    return Result<IList<Matiere>>.Fail("NOT_FOUND", "Aucune matière trouvée pour l'année et la classe.", 404);
                }

                return Result<IList<Matiere>>.Ok(matieres, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération des matières pour l'année scolaire avec ID {anneeScoId}, la classe {classeId} et le professeur {professeurId}");
                return Result<IList<Matiere>>.Fail("ECHEC", "Erreur lors de la récupération des matières.", 500);
            }
        }

        public async Task<Result<Matiere>> RecupererMatiereAyantLePlusFortCoeff(int anneeScoId, int classeId)
        {
            try
            {
                var matieres = await _enseignerRepository
                    .Query()
                    .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId)
                    .Join(
                        _matiereRepository.Query(),
                        enseigner => enseigner.MatiereId,
                        matiere => matiere.Id,
                        (enseigner, matiere) => new { Matiere = matiere, Coeff = enseigner.Coefficient }
                    )
                    .OrderByDescending(x => x.Coeff) // On trie par le Coefficient venant de Enseigner
                    .Select(x => x.Matiere) // On ne garde que la Matière au final
                    .FirstOrDefaultAsync();

                if (matieres == null)
                {
                    return Result<Matiere>.Fail("NOT_FOUND", "Aucune matière trouvée pour l'année et la classe.", 404);
                }

                return Result<Matiere>.Ok(matieres, 200);
            }
            catch (Exception)
            {
                _logger.LogError($"Erreur lors de la récupération des matières pour l'année scolaire avec ID {anneeScoId} et la classe {classeId}");
                return Result<Matiere>.Fail("ECHEC", "Erreur lors de la récupération des matières.", 500);
            }
        }

        
    }
}
