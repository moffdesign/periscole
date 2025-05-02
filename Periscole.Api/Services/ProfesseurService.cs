using Periscole.Api.Contrats;
using Periscole.Bdd.Domaine;

namespace Periscole.Api.Services
{
    public class ProfesseurService : IProfesseurService
    {
        

        public Task<Result<Professeur>> AjouterProfesseurAsync(Professeur professeur)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> ModifierProfesseurAsync(Professeur professeur)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Professeur>> RecupererProfesseurAsync(int professeurId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Professeur>>> RecupererProfesseursAsync(int? anneeScoId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Professeur>>> RecupererProfesseursClasseAsync(int anneeScoId, int classeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SupprimerProfesseurAsync(int professeurId)
        {
            throw new NotImplementedException();
        }


        public Task<Result<bool>> AffecterProfesseursClasseAsync(int anneeScoId, int classeId, IList<Professeur> professeurs)
        {
            throw new NotImplementedException();
        }

        Task<Result<Professeur>> IProfesseurService.ModifierProfesseurAsync(Professeur professeur)
        {
            throw new NotImplementedException();
        }
    }
}
