using Microsoft.EntityFrameworkCore;
using Periscole.Api.Contrats;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Contrats;

namespace Periscole.Api.Services
{
    public class SequenceService : ISequenceService
    {
        private readonly IGenericRepository<Sequence> _sequenceRepository;
        private readonly ILogger<MatiereService> _logger;

        public SequenceService(IGenericRepository<Sequence> sequenceRepository, ILogger<MatiereService> logger)
        {
            _sequenceRepository = sequenceRepository;
            _logger = logger;
        }

        public Task<Result<IList<Sequence>>> RecupererSequenceClasseAnneeSco(int anneeScoId, int classeId, int numeroSequence)
        {
            throw new NotImplementedException();
        }
        public Task<Result<bool>> EnregistrerNotesSequenceClasse(int anneeScoId, int classeId, int numeroSequence, IList<NoteSequence> notesSequence)
        {
            throw new NotImplementedException();
        }
        public Task<Result<bool>> ModifierNotesSequenceEleve(int anneeScoId, int classeId, int eleveId, int numeroSequence, NoteSequence noteSequence)
        {
            throw new NotImplementedException();
        }
        public Task<Result<bool>> InitialiserSequenceClasse(int anneeScoId, int classeId, int numeroSequence)
        {
            throw new NotImplementedException();
        }
    }
}
