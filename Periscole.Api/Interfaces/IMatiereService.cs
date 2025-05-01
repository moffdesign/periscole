using Periscole.Bdd.Domaine;

namespace Periscole.Api.Interfaces
{
    public interface IMatiereService
    {
        Task<Result<bool>> AjouterMatiere(Matiere matiere);

        Task<Result<bool>> ModifierMatiere(Matiere matiere);

        Task<Result<bool>> SupprimerMatiere(int matiereId);
        Task<Result<Matiere>> RecupererMatiere(int matiereId);

        Task<Result<IList<Matiere>>> RecupererListeMatieres();

        Task<Result<IList<Matiere>>> RecupererMatieresAnneeSco(int anneeScoId);

        Task<Result<IList<Matiere>>> RecupererMatieresProfesseur(int anneeScoId, int professeurId);
        
        Task<Result<IList<Matiere>>> RecupererMatieresClasseAnneeSco(int anneeScoId, int classeId);
        
        Task<Result<IList<Matiere>>> RecupererMatieresParClasseProfesseurAnneeSco(int anneeScoId, int classeId, int professeurId);


        Task<Result<Matiere>> RecupererMatiereAyantLePlusFortCoeff(int anneeScoId, int classeId);


    }
}
