using Periscole.Bdd.Domaine;

namespace Periscole.Api.Interfaces
{
    public interface ISequenceService
    {
        Task<Result<IList<Sequence>>> RecupererSequenceClasseAnneeSco(int anneeScoId, int classeId, int numeroSequence);

        Task<Result<bool>> EnregistrerNotesSequenceClasse(int anneeScoId, int classeId, int numeroSequence, IList<NoteSequence> notesSequence);

        Task<Result<bool>> ModifierNotesSequenceEleve(int anneeScoId, int classeId, int eleveId, int numeroSequence, NoteSequence noteSequence);

        Task<Result<bool>> InitialiserSequenceClasse(int anneeScoId, int classeId, int numeroSequence);


    }
}
