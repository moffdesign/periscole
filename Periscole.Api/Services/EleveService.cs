using Periscole.Api.Interfaces;
using Periscole.Bdd.Domaine;

namespace Periscole.Api.Services
{
    public class EleveService : IEleveService
    {
        public Task<Result<Eleve>> AjouterEleveAsync(Eleve eleve)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Eleve>> GetEleveByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Eleve>>> GetElevesByNomPrenomAsync(string? nom, string? prenom)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Eleve>> ModifierEleveAsync(Eleve eleve)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Eleve>>> RecupererElevesAnneeScoAsync(int anneeScoId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Eleve>>> RecupererElevesClasseAsync(int anneeScoId, int classeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Eleve>>> RecupererListeElevesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SupprimerEleveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
