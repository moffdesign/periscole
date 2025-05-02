using Microsoft.EntityFrameworkCore;
using Periscole.Api.Contrats;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Contrats;

namespace Periscole.Api.Services
{
    public class AnneeScoService : IAnneeScoService
    {
        private readonly ILogger<AnneeScoService> _logger;
        private readonly IGenericRepository<AnneeSco> _anneeScoRepository;
        public AnneeScoService(ILogger<AnneeScoService> logger, IGenericRepository<AnneeSco> anneeScoRepository)
        {
            _logger = logger;
            _anneeScoRepository = anneeScoRepository;
        }

        public Task<Result<bool>> AjouterAnneeSco(AnneeSco anneeSco)
        {
            throw new NotImplementedException();
        }
        public Task<Result<bool>> ModifierAnneeSco(AnneeSco anneeSco)
        {
            throw new NotImplementedException();
        }
        public Task<Result<AnneeSco>> RecupererAnneeSco(int anneeScoId)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<IList<AnneeSco>>> ListeAnneesScolaires()
        {
            try
            {
                var anneesTask = await _anneeScoRepository.GetAllAsync();

                    if (anneesTask == null || !anneesTask.Any())
                    {
                        return Result<IList<AnneeSco>>.Fail("NOT_FOUND", "Aucune matière trouvée.", 404);
                    }
                    return Result<IList<AnneeSco>>.Ok(anneesTask.ToList(), 200);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération de la liste des années scolaires");
                return Result<IList<AnneeSco>>.Fail("ERROR", "Erreur lors de la récupération de la liste des années scolaires", 500);
            }
        }
        public Task<Result<bool>> SupprimerAnneeSco(int anneeScoId)
        {
            throw new NotImplementedException();
        }
    
    }
}
