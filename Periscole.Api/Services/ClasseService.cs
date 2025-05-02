using Periscole.Api.Contrats;
using Periscole.Bdd.Domaine;

namespace Periscole.Api.Services
{
    public class ClasseService : IClasseService
    {
        public Task<Result<bool>> AjouterClasse(Classe classe)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> ModifierClasse(Classe classe)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Classe>> RecupererClasse(int classeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Classe>>> RecupererClasses(int? anneeScoId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Classe>>> RecupererClassesParProfesseur(int anneeScoId, int professeurId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Classe>>> RecupererMatieresClasse(int anneeScoId, int classeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SupprimerClasse(int classeId)
        {
            throw new NotImplementedException();
        }
    }
}
